using _05_reflection.PlugInterface;

namespace _05_reflection.Plugins
{
    public class OnlyVowels : IPlugin
    {
        public string Command { get; } = "vowels";
        public string Run(string input){
            string vowels = "";
            foreach(var ch in input){
                if("AEIOUaeiouАЕЁИОУЫЭЮЯаеёиоуыэюя".Contains(ch))
                    vowels += ch;
            }
            return vowels;
        }
    }
}