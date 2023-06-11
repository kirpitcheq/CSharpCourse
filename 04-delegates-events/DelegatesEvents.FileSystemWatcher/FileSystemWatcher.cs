using System.Timers;
namespace DelegatesEvents;

public class FileSystemWatcher
{
    private readonly System.Timers.Timer timer = new System.Timers.Timer();
    public enum ChangesTypeDef {ADDED, CHANGED, DELETED}
    public class Notify
    {
        public ChangesTypeDef TypeOfChange { get; set; }
        public string RelativePath { get; set; } = "";
        DateTime TimeOfChanges { get; set; }
    }

    public delegate List<Notify> FilesChanged();
    public event FilesChanged? Change;

    
    //constr
    public FileSystemWatcher(double CheckedInterval)
    {
        if(CheckedInterval < 0)
            CheckedInterval = Math.Abs(CheckedInterval);
        timer.Interval = CheckedInterval;
        timer.Stop();
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
        if( Change != null ) {
        }
    }

}
