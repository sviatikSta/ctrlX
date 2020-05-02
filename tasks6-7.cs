using System;

namespace Завдання_6_7
{
    public static class Matem //статичний клас 
    {
        public static void Info(int[] Array, int i) 
        {
            Console.WriteLine(Array[i]);
        }

        public static int Max(int[] Array)
        {
            int max = 0;
            for (int i = 0; i < 20; i++)
            {
                if (max < Array[i]) max = Array[i];
            }
            return max;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] A = new int[20];
            for (int i = 0; i < 20; i++)
            {
                A[i] = rnd.Next(0, 50);
                Matem.Info(A, i); 
            }

            Console.WriteLine("Максимальне значення - {0}", Matem.Max(A)); 
        }
    }
}