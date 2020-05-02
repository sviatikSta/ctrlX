using System;

namespace Завдання_1
{
    class Student
    {
        public string surname;
        public string name;
        public int course;
        public int age;

        public Student() //не параметризовний конструктор. Завдання 1.
        {
            surname = "Винович";
            name = "Костянтин";
            course = 4;
            age = 20;
        }

        public Student(string surname, string name, int course, int age) //параметризований конструктор. Завдання 1.
        {
            this.surname = surname;
            this.name = name;
            this.course = course;
            this.age = age;
        }

        public void Info() //Метод для виводу інформації. Завдання 2.
        {
            Console.Write("Прізвище та ім'я: {0} {1} \nКурс: {2} \nВік: {3}\n", surname, name, course, age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[]A = new Student[10];

            A[0] = new Student(); //за допомогою не параметризованого конструктора. Завдання 3
            A[1] = new Student("Довганюк", "Анастасія", 3, 18); //за допомогою параметризованого конструктора. Завдання 3.
            A[2] = new Student("Козаріз", "Андрій", 5, 21);
            A[3] = new Student("Лесюк", "Ірина", 2, 17);
            A[4] = new Student("Марціновська", "Аліна", 5, 22);
            A[5] = new Student { surname = "Марціновська", name = "Аліна", course = 5, age = 22 }; //за допомогою ініціалізатора. Завд 3.
            A[6] = new Student { surname = "Рибак", name = "Юлія", course = 3, age = 18 };
            A[7] = new Student { surname = "Сандуляк", name = "Андрій", course = 5, age = 23 };
            A[8] = new Student { surname = "Сіранюк", name = "Владислав", course = 1, age = 15 };
            A[9] = new Student { surname = "Скрипнюк", name = "Христина", course = 3, age = 19 };

            Console.WriteLine("Студенти, вік яких більше 20 років: ");

            for (int i = 0; i < 10; i++) //Завдання 4. Вік студентів, яким більше 20
            {
                if (A[i].age > 20) A[i].Info();
            }
        }
    }
}