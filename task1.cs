/*Напишіть програму, в якій оголошується делегат для методів з двома
аргументами (символ і текст) і цілочисельним результатом.В головному класі
необхідно описати два статичних методу. Один статичний метод результатом
повертає кількість входжень символу (Перший аргумент) в текстовий рядок
(другий аргумент). інший метод результатом повертає індекс першого
входження символу(перший аргумент) в текстовий рядок(другий аргумент),
або значення -1, якщо символ в текстовому рядку не зустрічається.У
головному методі створити екземпляр делегата і за допомогою цього
примірника викликати кожен з статичних методів. */
using System;

namespace Делегати
{
    public delegate int Delegate1(char sym, string txt);

    class Program
    {
        public static int Method1(char symbol, string text)
        {
            int count = 0;
            foreach (char sym in text)
            {
                if (sym == symbol)
                {
                    count++;
                }
            }
            return count;
        }

        public static int Method2(char symbol, string text)
        {
            int index = text.IndexOf(symbol);
            return index;
        }
        static void Main(string[] args)
        {
            Delegate1 search1;
            search1 = Method1;
            Console.WriteLine("Символ зустрічається у тексті {0} разів", search1('g', "It is delegates, baby!"));

            Delegate1 search2;
            search2 = Method2;
            Console.WriteLine("Індекс першого входження сииволу в рядок - {0}", search2('g', "It is delegates, baby!"));

            Console.ReadKey();
        }
    }
}