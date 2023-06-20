using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _05_reflection.PlugInterface;

namespace _05_reflection.Plugins
{
    public class OnlyConsonants : IPlugin
    {
        public string Command { get; } = "consonats";
        public string Run(string input){
            string consonants = "";
            foreach(var ch in input){
                if(!"AEIOUaeiouАЕЁИОУЫЭЮЯаеёиоуыэюя".Contains(ch) && !char.IsDigit(ch))
                    consonants += ch;
            }
            return consonants;
        }
    }
}