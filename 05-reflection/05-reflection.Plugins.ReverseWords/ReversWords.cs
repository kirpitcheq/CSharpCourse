using _05_reflection.PlugInterface;

namespace _05_reflection.Plugins
{
    public class ReversWords : IPlugin
    {
        public string Command { get; } = "revwords";
        public string Run(string input){
            var splitted = input.Split(" ");
            string revwords = "";
            foreach(var i in splitted)
            {
                var reverse = new string (i.Reverse().ToArray());
                revwords += reverse + " ";
            }
            return revwords;
        }
    }
}