using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_teach_me_how_to_type
{
    public class TeachHowType
    {
        const string welcome_text =
            "Welcome to the \"Teach Me How To Type\" speed test program! We are glad to welcome you here and hope that our program will help you improve your writing skills. Press Enter to start: ";

        public void StartTraining()
        {
            bool need_again = false;
            Console.WriteLine(dictionary[langSelect][0]);

            Console.ReadLine(); // need Enter for start
            Statistic Stats = new Statistic(langSelect);
            do
            {
                string training_text = getRandomTrainingText();
                Console.WriteLine(training_text);
                DateTime BeginTime = DateTime.Now;
                string user_text = Console.ReadLine();
                DateTime EndTime = DateTime.Now;
                TimeSpan ResultTime = EndTime - BeginTime;

                TextChecker textChecker = new TextChecker(2, ResultTime, langSelect); 

                textChecker.textsCompare(training_text, user_text);

                //double type_speed = user_text.Length / ResultTime.TotalMinutes; //Тут нужно выводить скорость правильной печати!
                textChecker.calcTrueTypeSpeed();

                //Console.WriteLine("Your printing speed is {0} ch/min, and you made {1} mistakes", type_speed, numb_of_typos);
                Console.WriteLine(textChecker);

                Stats.ItersResults.Add(textChecker);
                Console.WriteLine(Stats);

                if(langSelect == LangTypeDef.Russian)
                    Console.WriteLine("Вы хотите начать заново? Нажмите enter, если да, или введите что-нибудь еще, если нет: ");
                else
                Console.WriteLine("Do you want to start again? Press enter if yes or enter anything else if no: ");
                need_again = Console.ReadLine() == string.Empty ? true : false;
            } while (need_again);
        }


        /*--------------------------------------------------------------------------------*/
        //Stage 2. Различные варианты текстов. 

        List<string> training_texts = new List<string>()
        {
            welcome_text,
            "The quick brown fox jumps over the lazy dog.",
            "Pack my box with five dozen liquor jugs.",
            "The cat sat on the windowsill, watching the world go by.",
            "The sun slowly set behind the mountains, painting the sky with hues of orange and pink."
        };
        Dictionary<LangTypeDef, List<string>> dictionary = new Dictionary<LangTypeDef, List<string>>();
        string getRandomTrainingText()
        {
            Random random = new Random();
            int random_index = (int)random.NextInt64(1, dictionary[langSelect].Count); //0-я строка зарезервирована Приветствием на разных языках
            return dictionary[langSelect][random_index];
        }


        /*--------------------------------------------------------------------------------*/
        //Stage 3. Анализ ошибок.
        internal class TextChecker
        {
            uint ref_text_index;
            public int numb_of_typos { get; private set; }
            public double true_type_speed_per_min { get; private set; }
            TimeSpan type_time;
            int userTextLen;
            LangTypeDef used_lang;

            public TextChecker(uint ref_text_index, TimeSpan type_time, LangTypeDef used_lang)
            {
                this.ref_text_index = ref_text_index;
                this.type_time = type_time;
                this.used_lang = used_lang;
            }
            public uint textsCompare(string ref_text, string user_text)
            {
                numb_of_typos = LevensteinDist(ref_text, user_text);
                return (uint)numb_of_typos;
            }
            int LevensteinDist(string ref_text, string user_text)
            {
                userTextLen = user_text.Length;
                //Задаём матрицу для алгоритма поиска расстояния Левенштейна
                int[,] lev_mtrx = new int[ref_text.Length + 1, user_text.Length + 1];

                //начальное значение для расчёта
                lev_mtrx[0, 0] = 0; //всё и так инициализировано нулями, но для явного выделения точки старта алгоритма
                                    //необходимо инициализировать матрицу начальными значениями
                for (int i = 0; i < ref_text.Length + 1; i++)
                    lev_mtrx[i, 0] = i;
                for (int j = 0; j < user_text.Length + 1; j++)
                    lev_mtrx[0, j] = j;

                int temp = 0;
                for (int i = 1; i < ref_text.Length + 1; i++)
                {
                    for (int j = 1; j < user_text.Length + 1; j++)
                    {
                        if (ref_text[i - 1] == user_text[j - 1])
                            temp = lev_mtrx[i - 1, j - 1];
                        else
                            temp = lev_mtrx[i - 1, j - 1] + 1;
                        if (temp > lev_mtrx[i - 1, j] + 1)
                            temp = lev_mtrx[i - 1, j] + 1;
                        if (temp > lev_mtrx[i, j - 1] + 1)
                            temp = lev_mtrx[i, j - 1] + 1;

                        lev_mtrx[i, j] = temp;
                    }
                }
                return lev_mtrx[ref_text.Length, user_text.Length];
            }
        
            public double calcTrueTypeSpeed()
            {
                return true_type_speed_per_min = (userTextLen - numb_of_typos) / type_time.TotalMinutes; //Тут нужно выводить скорость правильной печати!
            }

            public override string ToString()
            {
                if(used_lang == LangTypeDef.Russian)
                    return new string(
                       "-------------------------------------------------------------------\n" +
                       "Ваша скорость печати " + true_type_speed_per_min + " символ/мин, " +
                        "и у вас " + numb_of_typos + " ошибок." 
                       + "\n-------------------------------------------------------------------\n"
                        );
     
                return new string(
                   "-------------------------------------------------------------------\n" +
                   "Your printing speed is " + true_type_speed_per_min + " ch/min, " +
                    "and you made " + numb_of_typos + " mistakes"
                   + "\n-------------------------------------------------------------------\n"
                    );
            }
        }
        /*--------------------------------------------------------------------------------*/
        //Stage 4. Выбор языка.
        const string welcome_text_rus =
            "Добро пожаловать в программу тестирования скорости \"Научи меня печатать\"! Мы рады приветствовать вас здесь и надеемся, что наша программа поможет вам улучшить свои навыки письма. Нажмите Enter, чтобы начать: ";
        List<string> training_texts_rus = new List<string>()
        {
            welcome_text_rus,
            "Быстрая бурая лиса перепрыгивает через ленивую собаку.",
            "Набери в мою коробку пять дюжин кувшинов с ликером.",
            "Кот сидел на подоконнике, наблюдая за проплывающим мимо миром.",
            "Солнце медленно садилось за горы, окрашивая небо в оранжевые и розовые тона."
        };
        public enum LangTypeDef { Russian, English };
        public LangTypeDef langSelect { get; set; } = LangTypeDef.English;
        public TeachHowType()
        {
            fillDictionary();
        }
        void fillDictionary()
        {
            dictionary.Add(LangTypeDef.English, training_texts);
            dictionary.Add(LangTypeDef.Russian, training_texts_rus);
        }
        const string ChoiseYourLang_text = "Please select a language, the default language is English (please type enter if English, or type Rus or something else for Russian): ";
        public void selectLangInteractive()
        {
            Console.WriteLine(ChoiseYourLang_text);
            langSelect = Console.ReadLine() == string.Empty ? LangTypeDef.English : LangTypeDef.Russian;
        }
        //Stage 5. Статистика. 

        internal class Statistic
        {
            LangTypeDef used_lang;
            public Statistic(LangTypeDef used_lang) => this.used_lang = used_lang;

            public List<TextChecker> ItersResults { get; set; } = new List<TextChecker>();
            public override string ToString()
            {
                if(used_lang == LangTypeDef.Russian)
                    return new string(
                                    "-------------------------------------------------------------------\n" +
                                    "У вас " + ItersResults.Count + " попыток, " +
                                    "средняя скорость печати " + ItersResults.Average(TextChecker => TextChecker.true_type_speed_per_min) +
                                    ", лучшая " + ItersResults.Max(TextChecker => TextChecker.true_type_speed_per_min) +
                                    ", худжая " + ItersResults.Min(TextChecker => TextChecker.true_type_speed_per_min) +
                                    "; ваши опечатки : в среднем " + ItersResults.Average(TextChecker => TextChecker.numb_of_typos) +
                                    ", лучший результат (минимум ошибок) " + ItersResults.Min(TextChecker => TextChecker.numb_of_typos) +
                                    ", худший результат (максимум ошибок) " + ItersResults.Max(TextChecker => TextChecker.numb_of_typos)
                                    + "\n-------------------------------------------------------------------\n"
                                     );

                return new string(
                                    "-------------------------------------------------------------------\n" +
                                    "You had " + ItersResults.Count + " attempts, " +
                                    "average speed " + ItersResults.Average(TextChecker => TextChecker.true_type_speed_per_min) +
                                    ", best " + ItersResults.Max(TextChecker => TextChecker.true_type_speed_per_min) +
                                    ", worse " + ItersResults.Min(TextChecker => TextChecker.true_type_speed_per_min) +
                                    "; your typos: average " + ItersResults.Average(TextChecker => TextChecker.numb_of_typos) +
                                    ", best (min) " + ItersResults.Min(TextChecker => TextChecker.numb_of_typos) +
                                    ", worse (max) " + ItersResults.Max(TextChecker => TextChecker.numb_of_typos) 
                                    + "\n-------------------------------------------------------------------\n"
                                 );
            }
        }
    }
}