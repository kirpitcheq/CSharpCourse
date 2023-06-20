using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_reflection.PlugInterface
{
    public interface IPlugin
    {
        public string Command { get; }
        public string Run(string args);
    }
}