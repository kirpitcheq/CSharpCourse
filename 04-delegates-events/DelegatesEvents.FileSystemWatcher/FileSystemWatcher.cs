using System;
using System.Threading;
using System.IO;
namespace DelegatesEvents;

public class FileSystemWatcher
{
    private readonly System.Timers.Timer timer = new System.Timers.Timer();
    // private readonly Timer timer = new Timer(TimerWent);
    public enum ChangesTypeDef {ADDED, CHANGED, DELETED}
    public class Notify
    {
        public ChangesTypeDef TypeOfChange { get; set; }
        public string RelativePath { get; set; } = "";
        DateTime TimeOfChanges { get; set; }
    }
    private string[] files { get; set; }
    private string path { get; set; } = "."; //this folder by default

    public delegate List<Notify> FilesChanged();
    public event FilesChanged? Change;

    
    //constr
    public FileSystemWatcher(double CheckedInterval)
    {
        if(CheckedInterval < 0)
            CheckedInterval = Math.Abs(CheckedInterval);
        timer.Interval = CheckedInterval;
        timer.Stop();
        timer.Elapsed += TimerWent!;
    }
    private void TimerWent(object sender, EventArgs args) {
        var files_now = System.IO.Directory.GetFiles(path);
        if(files_now == null)
        {
            if(files != null)
                
                //event all files are deleted (call changed event)
            
        }
            return;
        //add, del, change
        foreach(var file in files_now) {
            var fileinfo = new FileInfo(file);
            var filesize = fileinfo.Length;
            var filecreation = fileinfo.CreationTime;
        }
    }

    private const double default_interval = 1000.0;
    public FileSystemWatcher() : this(default_interval) { }

    public bool Subscribe (FilesChanged func) {
        if(func == null) return false;
        Change += func;
        if(!timer.Enabled)
            timer.Start();
        return true;
    }

    public void Unsubscribe(FilesChanged func)
    {
        
    }

}
