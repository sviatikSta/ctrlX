using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Завдання_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            //task 1
            string text = "Визначений інтеграл - в математичному аналізі " +
                "це інтеграл функції з вказаною областю інтегрування. " +
                "Визначений інтеграл є неперервним функціоналом, лінійним по підінтегральним функціям" +
                " і адитивним по області інтегрування.";
            string substring = "підрядок";
            int lengthOfWord = 8;

            string[] words = text.Split(new char[] { ',', ' ', '-', '.'});

            foreach (string word in words)
            {
                if (word.Length == lengthOfWord)
                {
                    Console.Write(substring);
                    Console.Write(" ");
                }

                else
                {
                    Console.Write(word);
                    Console.Write(" ");
                }
            }

            //task 2
            Console.WriteLine("\n----task 2----");
            int k = 8;

            foreach (char symbol in text)
            {
                if (text.IndexOf(symbol) % k == 0 && text.IndexOf(symbol) != 0)
                {
                    Console.Write(symbol);
                    Console.Write(substring);
                }

                else
                {
                    Console.Write(symbol);
                }
            }

            //task 3
            Console.WriteLine("\n----task 3----");

            int count = 0; //кількість повторення слова

            //видаляємо розділові знаки
            string newText = text.Replace("-", "");
            newText = newText.Replace(",", "");
            newText = newText.Replace(".", "");

            string[] words1 = newText.Split(new char[] { ' ' }); //розділяємо текст без розд.знаків на окремі слова

            foreach (string word in words1) //Оючислення кількості повторень кодного слова
            {
                string word1 = word;
                foreach (string word2 in words1)
                {
                    if (word1 == word2) count++;
                }
                Console.WriteLine(word1 + " - " + count);
                count = 0;
            }

            //task 4
            Console.WriteLine("\n----task 4----");

            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            Console.WriteLine(ti.ToTitleCase(text));

            Console.ReadKey();
        }
    }
}