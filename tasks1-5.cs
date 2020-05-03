using System;

namespace Завдання
{
    class Person //Завдання 1
    {
        private string surname;
        private string name;
        private int age;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person (string Name, string Surname, int Age)
        {
            surname = Surname;
            name = Name;
            age = Age;
        }

        public void Info()
        {
            Console.WriteLine("Прізвище та ім'я: {0} {1} \nВік: {2}", surname, name, age);
        }
    }

    class Student: Person //Завдання 2
    {
        private string courseName;
        private int countOfLessons;

        public Student (string surname, string name, int age, string courseName, int countOfLessons) : base (surname, name, age)
        {
            this.courseName = courseName;
            this.countOfLessons = countOfLessons; 
        }

        public void Info()
        {
            Console.WriteLine("Прізвище та ім'я: {0} {1} \nВік: {2}", Surname, Name, Age);
            Console.WriteLine("Прослуханий курс: {0} \nКількість занять: {1}", courseName, countOfLessons);
        }
    }

    sealed class Teacher: Person //Завдання 3
    {
        private string courseName1;
        private string courseName2;

        public Teacher(string surname, string name, int age, string CourseName1, string CourseName2) : base(surname, name, age)
        {
            courseName1 = CourseName1;
            courseName2 = CourseName2;
        }

        public void Info()
        {
            Console.WriteLine("Прізвище та ім'я: {0} {1} \nВік: {2}", Surname, Name, Age);
            Console.WriteLine("Курс 1: {0} \nКурс 2: {1}", courseName1, courseName2);
        }
    }

    abstract class Course //Завдання 4
    {
        private string courseName;
        private int lessons;
        private int countOfStudents;

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public int Lessons
        {
            get { return lessons; }
            set { lessons = value; }
        }

        public int CountOfStudents
        {
            get { return countOfStudents; }
            set { countOfStudents = value; }
        }

        public abstract void Info();
    }

    class CurrentCourse : Course //Завдання 5
    {
        private string expirationdate;

        public CurrentCourse (string courseName, int lessons, int countOfStudents, string Expirationdate)
        {
            CourseName = courseName;
            Lessons = lessons;
            CountOfStudents = countOfStudents;
            expirationdate = Expirationdate;
        }

        public override void Info()
        {
            Console.WriteLine("Назва курсу: {0} \nКількість занять: {1} \nКількість студентів: {2} \nДата завершення: {3}", CourseName, Lessons, CountOfStudents, expirationdate);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            //Виведення інформації на екран
            Person Object1 = new Person("Денис", "Петров", 27);
            Object1.Info();
            Console.WriteLine();

            Student Object2 = new Student("Цаль", "Віталій", 29, "Психологія", 15);
            Object2.Info();
            Console.WriteLine();
            
            Teacher Object3 = new Teacher("Жмишенко", "Валерій", 54, "Психологія", "Українська мова");
            Object3.Info();
            Console.WriteLine();
            
            CurrentCourse Object4 = new CurrentCourse("Психологія", 20, 47, "09.05.2020");
            Object4.Info();
        }
    }
}