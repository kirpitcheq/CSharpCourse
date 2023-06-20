using _05_reflection.PlugInterface;

namespace _05_reflection.Plugins
{
    public class OnlyLetters : IPlugin
    {
        public string Command { get; } = "letters";
        public string Run(string input){
            string letters = "";
            foreach(var ch in input){
                if(char.IsLetter(ch))
                    letters += ch;
            }
            return letters;
        }
    }
}