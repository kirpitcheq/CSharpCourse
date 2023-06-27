using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;

using _04_delegates_events;

const string path = "~/tests/";
if(!Directory.Exists(path))
    Directory.CreateDirectory(path);

var fileSystemWatcher = new _04_delegates_events.FileSystemWatcher();

_04_delegates_events.FilesChanged filesChanged;
filesChanged = ConvertAndShowMessage;

                    //Subscribe
fileSystemWatcher.Change += filesChanged;

Thread.Sleep(353);  //CREATE NOTIFY
Directory.CreateDirectory(path+"test1dir");
string pathfile = path+"test1dir/file.txt";
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Test write into text file");
}

Thread.Sleep(234);  //CHANGE NOTIFY
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Another Test write write into text file");
}

Thread.Sleep(334);  //CHANGE NOTIFY ONE MORE
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Another Another Test write write into text file");
}

Thread.Sleep(324);  //DELETE NOTIFY
File.Delete(path+"test1dir/file.txt");

Thread.Sleep(224);  //Unsubscrube
fileSystemWatcher.Change -= filesChanged;

//try one more same but no notifies!
Thread.Sleep(353);  //CREATE NOTIFY
pathfile = path+"test1dir/file.txt";
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Test write into text file");
}

Thread.Sleep(234);  //CHANGE NOTIFY
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Another Test write write into text file");
}

Thread.Sleep(334);  //CHANGE NOTIFY ONE MORE
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Another Another Test write write into text file");
}

Thread.Sleep(324);  //DELETE NOTIFY
File.Delete(path+"test1dir/file.txt");

Thread.Sleep(224);  //Subscribe again
fileSystemWatcher.Change += filesChanged;

//try one more same but no notifies!
Thread.Sleep(353);  //CREATE NOTIFY
Directory.CreateDirectory(path+"test1dir");
pathfile = path+"test1dir/file.txt";
using (var stream = new StreamWriter(File.Open(pathfile, FileMode.OpenOrCreate))) {
    stream.Write("Test write into text file");
}

Thread.Sleep(324);  //DELETE NOTIFY
File.Delete(path+"test1dir/file.txt");

Thread.Sleep(1000);  //end

//----------------------------------------------------------------------------------------
static void ConvertAndShowMessage(List<_04_delegates_events.FileSystemWatcher.Notify> notifies){
    if (notifies!=null)
        foreach (var notify in notifies)
            System.Console.WriteLine(notify);
}