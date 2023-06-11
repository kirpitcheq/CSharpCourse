namespace DelegatesEvents;

public class FileSystemWatcher
{
    enum ChangesTypeDef {ADDED, CHANGED, DELETED}
    class Notify
    {
        public ChangesTypeDef TypeOfChange { get; set; }
        public string RelativePath { get; set; } = "";
    }

    private delegate List<Notify> FilesChanged();
    public event FilesChanged? Change;
}
