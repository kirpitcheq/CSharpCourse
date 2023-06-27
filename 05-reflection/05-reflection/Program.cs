using System;
using System.IO;
using System.Reflection;
using _05_reflection.PlugInterface;
using static System.Console;

//зарегистрировать плагин
//создать интерфейс для плагина
var plugins = GetPlugins();

var dict = GetPlugFuncs(plugins);
var plugshelp = GetHelpStrings(plugins);
const string HelpMesage = "Put \"exit\" to exit or \"help\" for commands info of loaded plugins: ";
string readline;
do{
    WriteLine(HelpMesage);
    readline = ReadLine()!;
    switch(readline){
        case "exit": 
            break; 
        case "help": 
            foreach(var help in plugshelp)
                WriteLine(help);
            break;
        default:
            RunFunction runFunction;
            try
            {
                runFunction = dict[readline];
            }
            catch (System.Exception)
            {
                WriteLine("Wrong command\n");
                continue;
            }
            WriteLine("Type your string arg: ");
            var str = ReadLine();
            var plugresult = runFunction(str);
            System.Console.WriteLine("Your result: " + plugresult + "\n");
            break;
    }

}while(readline != "exit");

//---------------------------------------------------------------------
List<IPlugin> GetPlugins()
{
    List<IPlugin> plugins = new List<IPlugin>();
    var dlls = Directory.GetFiles("./plugins", "*.dll");

    foreach (var dll in dlls){
        var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(),dll));
        var PlgType = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface).ToList();
        foreach(var p in PlgType){
            var PlgInstance = Activator.CreateInstance(p) as IPlugin;
            plugins.Add(PlgInstance!);
        }
    }
    return plugins;
}

//настроить сохранение dll проектов плагинов в plugins 
//составить основную прогу

string[] GetHelpStrings(List<IPlugin> plugins){
    string[] result = new string[plugins.Count + 2];
    const string divider = "----------------------------------------------\n";
    result[0] = divider;
    result[0] += $"Loaded {plugins.Count} plugins. ";
    if(plugins.Count > 0)result[0] += "You can use next commands: ";
    int indx = 1;
    foreach(IPlugin plugin in plugins){
        result[indx++] = plugin.Command;
    }
    result[indx] = divider;
    return result;
}
Dictionary<string, RunFunction> GetPlugFuncs(List<IPlugin> plugins){
    var dictres = new Dictionary<string, RunFunction>();
    foreach(var plug in plugins){
        dictres.Add(plug.Command, plug.Run);
    }
    return dictres;
}
delegate string RunFunction(string args);