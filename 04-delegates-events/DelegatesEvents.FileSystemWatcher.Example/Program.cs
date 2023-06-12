using System.Runtime.CompilerServices;
using DelegatesEvents;
using System.IO;
using System.Threading;

const string path = "~/tests/";
if(!Directory.Exists(path))
    Directory.CreateDirectory(path);

DelegatesEvents.FileSystemWatcher fileSystemWatcher = new DelegatesEvents.FileSystemWatcher();

DelegatesEvents.FilesChanged filesChanged;
filesChanged = ConvertAndShowMessage;
fileSystemWatcher.Subscribe(filesChanged);

Thread.Sleep(2353);
Directory.CreateDirectory(path+"test1dir");
string pathfile = path+"test1dir/file.txt";
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Test write into text file");
}

Thread.Sleep(1234);
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Test write write into text file");
}

Thread.Sleep(4324);
File.Delete(path+"test1dir/file.txt");

Console.ReadLine();
//----------------------------------------------------------------------------------------
static void ConvertAndShowMessage(List<DelegatesEvents.FileSystemWatcher.Notify> notifies){
    if (notifies!=null)
        foreach (var notify in notifies)
            System.Console.WriteLine(notify);
}