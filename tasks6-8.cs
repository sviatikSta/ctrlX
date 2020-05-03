using System;

namespace Завдання_6
{
    partial class Student
    {
        public string surname;
        public string name;
        public int course;
        public int age;

        public void Info() 
        {
            Console.Write("\nПрізвище та ім'я: {0} {1} \nКурс: {2} \nВік: {3}\n", surname, name, course, age);
            Console.Write("Історія - {0}; Математика - {1}; Укр. мова - {2}; Англ. мова - {3}\n", History, Math, Ukrainian, English);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Student[] A = new Student[10];

            A[0] = new Student("Винович", "Костянтин", 4, 20, 3, 4, 5, 3); 
            A[1] = new Student("Довганюк", "Анастасія", 3, 18, 4, 4, 4, 5); 
            A[2] = new Student("Козаріз", "Андрій", 5, 21, 5, 5, 5, 5);
            A[3] = new Student("Лесюк", "Ірина", 2, 17, 5, 5, 5, 5);
            A[4] = new Student("Марціновська", "Аліна", 5, 22, 3, 2, 5, 3);
            A[5] = new Student ("Рибак", "Юлія", 3, 17, 4, 4, 5, 3); 
            A[6] = new Student ("Сандуляк", "Андрій", 5, 23, 3, 4, 4, 4);
            A[7] = new Student ("Сіранюк", "Владислав", 1, 15, 2, 2, 2, 2);
            A[8] = new Student ("Скрипнюк", "Христина", 3, 19, 5, 5, 5, 5);
            A[9] = new Student ("Тимофійчук", "Віталіна", 2, 16, 3, 2, 3, 4);

            Console.WriteLine("\n=================================================================");
            Console.WriteLine("Студенти, які отримали двійку:"); //Завдання 7.
            for (int i = 0; i<10; i++)
            {
                if (A[i].History == 2 || A[i].Math == 2 || A[i].Ukrainian == 2 || A[i].English == 2)
                    A[i].Info();
            }

            Console.WriteLine("\n=================================================================");
            Console.WriteLine("\nСтуденти, які отримали всі п'ятірки, переміщені на початок:");
            for (int j = 0; j < 10; j++)
            {
                if (A[j].History == 5 && A[j].Math == 5 && A[j].Ukrainian == 5 && A[j].English == 5)
                    A[j].Info();
            }
            for (int j = 0; j < 10; j++)
            {
                if (A[j].History != 5 || A[j].Math != 5 || A[j].Ukrainian != 5 || A[j].English != 5)
                    A[j].Info();
            }
            Console.ReadKey();
        }
    }
}