using System;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;

namespace DelegatesEvents
{
    public delegate void FilesChanged(List<DelegatesEvents.FileSystemWatcher.Notify> notifies);
    public class FileSystemWatcher
    {
        private readonly System.Timers.Timer timer = new System.Timers.Timer();
        // private readonly Timer timer = new Timer(TimerWent);
        public enum ChangesTypeDef { ADDED, CHANGED, DELETED }
        public class Notify {
            public ChangesTypeDef TypeOfChange { get; set; }
            public string RelativePath { get; set; } = "";
            DateTime TimeOfChanges { get; set; }
            public Notify(ChangesTypeDef typeOfChange, string relativePath) {
                TimeOfChanges = DateTime.Now;
                TypeOfChange = typeOfChange;
                RelativePath = relativePath;
            }
            override public string ToString() { return "File "+ RelativePath + " is " + TypeOfChange + " at " + TimeOfChanges; }
        }
        private string[] files { get; set; }
        private string path { get; set; } = "."; //this folder by default

        public event FilesChanged? Change;


        //constr
        public FileSystemWatcher(double CheckedInterval) { //here need path, init dictionary to files
            if (CheckedInterval < 0)
                CheckedInterval = Math.Abs(CheckedInterval);
            timer.Interval = CheckedInterval;
            timer.Stop();
            timer.Elapsed += TimerWent!;
        }
        Dictionary<string, FileInfo> filesdict = new Dictionary<string, FileInfo>();
        private void TimerWent(object sender, EventArgs args) {
            List<Notify> notifies = new List<Notify>();
            var files_now = System.IO.Directory.GetFileSystemEntries(path, "", SearchOption.AllDirectories);
            //add, del, change
            foreach (var file in filesdict) {
                if (files_now.Contains(file.Key) == false)
                {
                    notifies.Add(new Notify (ChangesTypeDef.DELETED , file.Key));
                    filesdict.Remove(file.Key);
                }

            }
            foreach (var file in files_now) {
                var fileinfo = new FileInfo(file);
                // FileInfo fileinfonow = null;
                if (filesdict.TryGetValue(fileinfo.Name, out FileInfo fileinfonow)) {
                    //file added changed condition
                    if (fileinfonow?.Length != fileinfo.Length) {
                        fileinfonow = fileinfo;
                        notifies.Add(new Notify (ChangesTypeDef.CHANGED, file));
                    }
                }
                else  //file added condition
                {
                    filesdict.Add(file, fileinfo);
                    notifies.Add(new Notify(ChangesTypeDef.ADDED, file));
                }
                // var changes = filesdict
                //     .Where(x => x.Key == file || 
                //         x.Value.Length == fileinfo.Length || 
                //         x.Value.CreationTime == fileinfo.CreationTime)
                //     .ToList();
            }
            // here now have dictionary with old files and "files" with now state files
            if (notifies.Count > 0) {
                Change?.Invoke(notifies);
            }

        }

        private const double default_interval = 1000.0;
        public FileSystemWatcher() : this(default_interval) { }

        public bool Subscribe(FilesChanged func)
        {
            if (func == null) return false;
            Change += func;
            if (!timer.Enabled)
                timer.Start();
            return true;
        }

        public void Unsubscribe(FilesChanged func)
        {

        }

    }
}