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
var file = File.Open(path+"test1dir/file.txt", FileMode.Create);
using var streamwriter = new

Thread.Sleep(1234);

//----------------------------------------------------------------------------------------
static void ConvertAndShowMessage(List<DelegatesEvents.FileSystemWatcher.Notify> notifies){
    if (notifies!=null)
        foreach (var notify in notifies)
            System.Console.WriteLine(notify);
}