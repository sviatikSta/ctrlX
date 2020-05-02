using System;

namespace Завдання_5
{
    class Student
    {
        public void scholarship(double month1)
        {
            Console.WriteLine("Ваша стипендія за 1 місяць склала - ", month1);
        }

        public void scholarship(double month1, double month2)
        {
            Console.WriteLine("Ваша стипендія за 2 місяці склала - {0}", (month1+month2));
        }

        public void scholarship(double month1, double month2, double month3)
        {
            Console.WriteLine("Ваша стипендія за 3 місяці склала - {0}", (month1+month2+month3));
        }

        public void scholarship(double month1, double month2, double month3, double month4)
        {
            Console.WriteLine("Ваша стипендія за 4 місяці склала - {0}", (month1+month2+month3+month4));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Object1 = new Student();
            Object1.scholarship(1467.78, 1453.21);
        }
    }
}