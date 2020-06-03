/*Напишіть програму, в якій є статичний метод.Першим аргументом статичного
методу передається цілочисельний масив. Другим аргументом статичного
методу передається посилання на інший метод.У методу-аргументу повинен
бути цілочисельний аргумент, і він повинен повертати цілочисельний
результат. Результатом статичний метод повертає цілочисельний масив.
Елементи цього масиву обчислюються як результат виклику методу-аргументу,
якщо йому передавати значення елементів з масиву-аргументу.Запропонуйте
механізм перевірки функціональності даного статичного методу.*/
using System;

namespace Delegate3
{
    delegate int Delegate1(int a);
    class Program
    {
        public static int[] Method1(int[]a, Delegate1 value)
        {
            int[] array = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                array[i]=value.Invoke(a[i]);
            }
            return array;
        }

        static public int Method2(int a) //Не працює, якщо цей метод не статичний
        {
            return a;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[5] { 0, 3, 2, 3, 4 };
            int[] arr2 = Method1(arr, Method2);

            for(int i = 0; i<arr2.Length; i++)
            {
                Console.WriteLine(arr2[i]);
            }
        }
    }
}
