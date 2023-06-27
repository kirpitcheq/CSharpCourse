# ДЗ 5. Reflection.

**Задание**

Разработайте консольное приложение с плагинами, подключаемыми на этапе исполнения через reflection.

**Требования**

- при запуске приложение загружает плагины из соседней папки `plugins`
- каждый загруженный плагин регистрирует обработчик команды запуска
- когда пользователь вводит текст в консоли, приложение проверяет, совпадает ли первое слово введённого текста с одной из зарегистрированных команд запуска
- если совпадает, то приложение запускает обработчик из плагина, отправляя ему на вход аргументы - часть текста, введённого пользователем, после команды запуска
- в приложении есть встроенная команда `help`, обработчик которой распечатывает все команды (в том числе help)

**Указания**

Для плагинов потребуется интерфейс. Он решит сразу 3 задачи:
1. Авторам плагинов будет проще выдержать контракт интеграции с вашим приложением
2. Вам будет удобно использовать этот интерфейс для работы с экземплярами плагинов
3. По этому интерфейсу вы найдёте в сторонних сборках плагины

Этот интерфейс потребуется и вашему приложению, и авторам плагинов. Поэтому его необходимо вынести в отдельную сборку. Создайте для этого в вашем solution второй проект - dll.

После сборки приложения вы получите 2 сборки - исполняемую (консольное приложение) и библиотеку с интерфейсом плагина (dll). Библиотека понадобится авторам плагинов. Автор плагина создаёт проект библиотеки, и в её зависимости добавляет вашу библиотеку. Остаётся лишь реализовать интерфейс и плагин готов. Для удобства разработки можете и приложение с библиотекой контракта, и плагины держать в одном solution. В свойствах проектов плагинов можете настроить output path так, чтобы после сборки они попадали в папку plugins в output path вашего основного приложения.

Для загрузки плагинов:
1. Найдите все файлы ".dll" в папке `plugins`
2. Загрузите сборки с помощью `Assembly.LoadFrom`. Вы получите экземпляры Assembly - типа, описывающего метаданные сборки
3. В полученных экземплярах ищите типы, реализующие ваш интерфейс. Сравнивайте не по имени, а с `typeof(ваш_интерфейс)`
4. Для найденных типов найдите конструктор без параметров и создайте экземпляры
5. Теперь можно работать с ними так, как будто это и не плагины вовсе, а данные вашей программы.

Пример интерфейса плагина:
```cs
public interface IPlugin
{
    string Command { get; }

    void Run(string args);
}
```

# Выполнено

Задание выполнено согласно требований:
- при запуске приложение загружает плагины из соседней папки `plugins`
```C#
var plugins = GetPlugins();
...
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
```
- каждый загруженный плагин регистрирует обработчик команды запуска
```C#
var dict = GetPlugFuncs(plugins);
...
Dictionary<string, RunFunction> GetPlugFuncs(List<IPlugin> plugins){
    var dictres = new Dictionary<string, RunFunction>();
    foreach(var plug in plugins){
        dictres.Add(plug.Command, plug.Run);
    }
    return dictres;
}
```
- когда пользователь вводит текст в консоли, приложение проверяет, совпадает ли первое слово введённого текста с одной из зарегистрированных команд запуска
    - производится проверкой совпадения ключа словаря и если отсутствует, то вызывает строку стандартных команд
- если совпадает, то приложение запускает обработчик из плагина, отправляя ему на вход аргументы - часть текста, введённого пользователем, после команды запуска
```bash
#пример
vowels
Type your string arg: 
Hello World 1234567890
Your result: eoo
```
- в приложении есть встроенная команда `help`, обработчик которой распечатывает все команды (в том числе help)
```C#
var plugshelp = GetHelpStrings(plugins); //save help strings with init of program after load plugs
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
```

---

Был задан интерфейс в проекте 05-reflection.PlugInterface
```C#
namespace _05_reflection.PlugInterface
{
    public interface IPlugin
    {
        public string Command { get; }
        public string Run(string args);
    }
}
```
, который реализован несколькими типами, вынесенные в отдельные проекты и подключенные к общему решению этой задачи, а идентификтор их начинается на `05-reflection.Plugins.<NAME_PLUGIN>:`
- 05-reflection.Plugins.OnlyConsonants
- 05-reflection.Plugins.OnlyLetters
- 05-reflection.Plugins.OnlyNumbs
- 05-reflection.Plugins.OnlyVowels
- 05-reflection.Plugins.ReverseWords

Для работы с данными типами в качестве плагинов был сформирован bash скрипт `clonePlugsDlls.sh`, в котором указаны инструкции: 
- удаление старых .dll файлов сборок из поддиректории `plugins` главной программы 
- а также поиск в поддиректориях `05-reflection.Plugins.<NAME_PLUGIN>:` .dll файлов и копия готовых сборок главной программы `plugin` согласно задания
```bash
#!/bin/sh
dotnet build
rm -rf 05-reflection/plugins/*
find . -type f -iregex "./05-reflection\.Plugins.*/bin/Debug/net7.0/05-reflection.Plugins.*\.dll" -exec cp {} 05-reflection/plugins/ \;
```
Вызов скрипта производится совместно с запуском основной программы при помощи инструкций настроек IDE VSCode в файле `.vscode/tasks.json`
```json
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/05-reflection.sln",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile",
            "dependsOn":["cpyplugdlls"]
        },
        {
            "label": "cpyplugdlls",
            "type": "shell",
            "command": "./clonePlugsDlls.sh"
        },
```
Ключевая инструкция - `"dependsOn":["cpyplugdlls"]`, которая указывает, что перед сборкой требуется сначала выполнить задачу, в которой указана команда выполнения скрипта

В случае ввода неверной комманды выводится соответствующее сообщение
```bash
Put "exit" to exit or "help" for commands info of loaded plugins: 
something
Wrong command
```

## Демонстрация работы основной программы
``` bash
X:~/assignments-csharp/05-reflection$  /.vscode/extensions/ms-dotnettools.csharp-2.0.238-linux-x64/.debugger/vsdbg --interpreter=vscode --connection=/tmp/CoreFxPipe_vsdbg-ui-5ee3bc74e2044f6d9008ebe3ce668a89 
Put "exit" to exit or "help" for commands info of loaded plugins: 
help
----------------------------------------------
Loaded 5 plugins. You can use next commands: 
vowels
numbs
letters
revwords
consonats
----------------------------------------------

Put "exit" to exit or "help" for commands info of loaded plugins: 
vowels
Type your string arg: 
Hello World 1234567890
Your result: eoo

Put "exit" to exit or "help" for commands info of loaded plugins: 
numbs
Type your string arg: 
Hello World 1234567890
Your result: 1234567890

Put "exit" to exit or "help" for commands info of loaded plugins: 
letters
Type your string arg: 
Hello World 1234567890
Your result: HelloWorld

Put "exit" to exit or "help" for commands info of loaded plugins: 
revwords
Type your string arg: 
Hello World 1234567890
Your result: olleH dlroW 0987654321 

Put "exit" to exit or "help" for commands info of loaded plugins: 
consonats
Type your string arg: 
Hello World 1234567890
Your result: Hll Wrld 

Put "exit" to exit or "help" for commands info of loaded plugins: 
something
Wrong command

Put "exit" to exit or "help" for commands info of loaded plugins: 
exit
```