using _05_reflection.PlugInterface;

namespace _05_reflection.Plugins
{
    public class OnlyNumbs : IPlugin
    {
        public string Command { get; } = "numbs";
        public string Run(string input){
            string numbs = "";
            foreach(var ch in input){
                if(char.IsNumber(ch))
                    numbs += ch;
            }
            return numbs;
        }
    }
}