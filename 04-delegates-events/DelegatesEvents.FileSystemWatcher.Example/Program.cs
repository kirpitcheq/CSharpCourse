// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using DelegatesEvents;

const string path = ".";

DelegatesEvents.FileSystemWatcher fileSystemWatcher = new DelegatesEvents.FileSystemWatcher();
// FilesChanged fileSystemWatcher;

DelegatesEvents.FilesChanged filesChanged;
filesChanged = ConvertAndShowMessage;
fileSystemWatcher.Subscribe(filesChanged);

Console.ReadLine();


static void ConvertAndShowMessage(List<DelegatesEvents.FileSystemWatcher.Notify> notifies){
// static void ConvertAndShowMessage(List<DelegatesEvents.FileSystemWatcher.Notify> notifies){
    if (notifies!=null)
        foreach (var notify in notifies)
            System.Console.WriteLine(notify);
}