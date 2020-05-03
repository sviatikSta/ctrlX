using System;

namespace Завдання_1_4
{
    interface IReaction1
    {
        void Reaction1();
    }

    interface IReaction2
    {
        void Reaction2();
    }

    interface IReaction3
    {
        void Reaction3();
    }

    class Animal
    {
        private string name;
        private string type;
        private string size;
        private string colour;
        private int countOfPaws;
        private string tail;

        public string _name
        {
            get { return name; }
            set { name = value; }
        }

        public string _type
        {
            get { return type; }
            set { type = value; }
        }

        public string _size
        {
            get { return size; }
            set { size = value; }
        }

        public string _colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public int _countOfPaws
        {
            get { return countOfPaws; }
            set { countOfPaws = value; }
        }

        public string _tail
        {
            get { return tail; }
            set { tail = value; }
        }

        public Animal(string _name, string _type, string _size, string _colour, int _countOfPaws, string _tail)
        {
            name = _name;
            type = _type;
            size = _size;
            colour = _colour;
            countOfPaws = _countOfPaws;
            tail = _tail;
        }

        public virtual void Info()
        {
            Console.WriteLine("Кличка: {0} \nТип: {1} \nРозмір: {2} \nКолір: {3} \nКількість лап: {4} \nНавність хвоста: {5}", name, type, size, colour, countOfPaws, tail);
        }

        public virtual void Voice()
        {
            Console.WriteLine("Voice");
        }
    }

    class Cat: Animal, IReaction1, IReaction3
    {
        private string species;
        private string lengthOfWool;

        public Cat(string _name, string _type, string _size, string _colour, int _countOfPaws, string _tail, string _species, string _lengthOfWool) :base(_name, _type, _size, _colour, _countOfPaws, _tail)
        {
            species = _species;
            lengthOfWool = _lengthOfWool;
        }

        public override void Info()
        {
            Console.WriteLine("Кличка: {0} \nТип: {1} \nРозмір: {2} \nКолір: {3} \nКількість лап: {4} \nНавність хвоста: {5}", _name, _type, _size, _colour, _countOfPaws, _tail);
            Console.WriteLine("Порода: {0} \nДовжина шерсті: {1}", species, lengthOfWool);
        }

        public override void Voice()
        {
            Console.WriteLine("- \"Мррррр\"");
        }

        public void Reaction1()
        {
            Console.WriteLine("- Втікає від незнайомців");
        }

        public void Reaction3()
        {
            Console.WriteLine(" - Ігнорує");
        }
    }

    class Dog: Animal, IReaction2, IReaction3
    {
        private string species;
        private string function;

        public Dog(string _name, string _type, string _size, string _colour, int _countOfPaws, string _tail, string _species, string _function) : base(_name, _type, _size, _colour, _countOfPaws, _tail)
        {
            species = _species;
            function = _function;
        }

        public override void Info()
        {
            Console.WriteLine("Кличка: {0} \nТип: {1} \nРозмір: {2} \nКолір: {3} \nКількість лап: {4} \nНавність хвоста: {5}", _name, _type, _size, _colour, _countOfPaws, _tail);
            Console.WriteLine("Порода: {0} \nПризначення: {1}", species, function);
        }

        public override void Voice()
        {
            Console.WriteLine("- \"Гав\"");
        } 

        public void Reaction2()
        {
            Console.WriteLine("- Подає голос та кидається на незнайомців");
        }

        public void Reaction3()
        {
            Console.WriteLine("- Ігнорує");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal animal1 = new Animal("Дженні", "Опосум", "Маленький", "Сірий", 4, "є");
            animal1.Info();
            Console.WriteLine();

            Animal animal2 = new Animal("Орео", "Єнот", "Середній", "Сірий", 4, "є");
            animal2.Info();
            Console.WriteLine();

            Animal animal3 = new Animal("Кокос", "Єнот", "Маленький", "Сірий", 4, "є");
            animal3.Info();
            Console.WriteLine();

            Cat animal4 = new Cat("Кабас", "Кіт", "Маленький", "Чорний", 4, "є", "Персидський кіт", "Довга");
            animal4.Info();
            Console.WriteLine();

            Cat animal5 = new Cat("Лілі", "Кіт", "Маленька", "Сіра", 4, "є", "Сіамська кішка", "Довга");
            animal5.Info();
            Console.WriteLine();

            Dog animal6 = new Dog("Догг", "Собака", "Середній", "Чорний/Коричневий", 4, "є", "Німецька вівчарка", "Мисливська");
            animal6.Info();
            Console.WriteLine();

            Dog animal7 = new Dog("Аркан", "Собака", "Середній", "Коричневий", 4, "є", "Сеттер", "Мисливська");
            animal7.Info();
            Console.WriteLine();

            Dog animal8 = new Dog("Анна", "Собака", "Середній", "Білий", 4, "є", "Лабрадор", "Мисливська");
            animal8.Info();
            Console.WriteLine();

            Console.WriteLine("Кішка: \nГолос: ");
            animal4.Voice();
            Console.WriteLine("Реакція на гостя:");
            animal4.Reaction1();
            animal4.Reaction3();
            Console.WriteLine();

            Console.WriteLine("Собака: \nГолос: ");
            animal6.Voice();
            Console.WriteLine("Реакція на гостя:");
            animal8.Reaction2();
            animal8.Reaction3();
            Console.WriteLine();

        }
    }
}