using System;

namespace Завдання_1
{
    class Matem
    {
        public void Info(int[] Array, int i) //метод для виводу елементів масиву. Завдання 1.
        {
            Console.WriteLine(Array[i]);
        }

        public int Max(int[] Array) //метод для пошуку максимального значення. Завдання 2.
        {
            int max = 0;
            for (int i = 0; i < 20; i++)
            {
                if (max < Array[i]) max = Array[i];
            }
            return max;
        }

        static public int Sum(int[] Array) //метод для знаходження суми всіх елементів масиву. Завдання 3
        {
            int sum = 0;
            for (int i = 0; i<20; i++)
            {
                sum += Array[i];
            }
            return sum;
        }

        static public int Product(int[] Array) //метод для знаходження добутку всіх елементів масиву. Завдання 3
        {
            int product = 1;
            for (int i = 0; i < 20; i++)
            {
                product *= Array[i];
            }
            return product;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] A = new int[20]; 
            for (int i = 0; i<20; i++)
            {
                 A[i] = rnd.Next(0, 50);
                 Matem output = new Matem();
                 output.Info(A, i); //вивід елемента на екран
            }

            Matem max = new Matem();
            Console.WriteLine("Максимальне значення - {0}", max.Max(A));  //Завдання 2

            string symbol; 
            Console.WriteLine("\nВведіть \"+\", якщо вам потрібно додати всі числа; \"*\", якщо помножити - ");
            symbol = Console.ReadLine();
            if (symbol == "+") Console.WriteLine(Matem.Sum(A)); //Завдання 3
            else if (symbol == "*") Console.WriteLine(Matem.Product(A)); //Завдання 3
            else Console.WriteLine("Ви ввели не той символ");
        }
    }
}