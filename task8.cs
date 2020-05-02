using System;

namespace Завдання_4
{
    class Student
    {
        public string surname;
        public string name;
        public int age;
        public static int count = 0;

        public Student(string surname, string name, int age) 
        {
            this.surname = surname;
            this.name = name;
            this.age = age;
        }

        static Student() //статичний конструктор. Завдання 8
        {
            Console.WriteLine("У класі створений статичний конструктор");
        }

        public static void GetCount()
        {
            count++;
        }

        public void Info() //Метод для виводу інформації. Завдання 2.
        {
            Console.Write("Прізвище та ім'я: {0} {1} \nВік: {2}\n", surname, name, age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Object1 = new Student ("Винович", "Костянтин", 19);
            Student.GetCount(); Object1.Info();
            Student Object2 = new Student("Довганюк", "Анастасія", 17);
            Student.GetCount(); Object2.Info();
            Student Object3 = new Student("Козаріз", "Андрій", 21);
            Student.GetCount(); Object3.Info();
            Student Object4 = new Student("Лесюк", "Ірина", 18);
            Student.GetCount(); Object4.Info();

            Console.WriteLine("Створено об'єктів - {0}", Student.count);
        }
    }
}