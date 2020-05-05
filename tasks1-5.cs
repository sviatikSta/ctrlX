using System;

namespace Завдання_1_6
{
    public class ComplexNumber
    {
        public int real { get; set; }
        public int imaginary { get; set; }

        public ComplexNumber(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        //task 1

        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            int newReal = num1.real + num2.real;
            int newImaginary = num1.imaginary + num2.imaginary;
            return new ComplexNumber(newReal, newImaginary);
        }

        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            int newReal = num1.real - num2.real;
            int newImaginary = num1.imaginary - num2.imaginary;
            return new ComplexNumber(newReal, newImaginary);
        }

        public static string operator ==(ComplexNumber num1, ComplexNumber num2)
        {
            return (num1.real == num2.real && num1.imaginary == num2.imaginary) ? "Числа рівні" : "Числа не рівні";
        }

        public static string operator !=(ComplexNumber num1, ComplexNumber num2)
        {
            return (num1.real == num2.real && num1.imaginary == num2.imaginary) ? "Числа рівні" : "Числа не рівні";
        }

        public static string operator >(ComplexNumber num1, ComplexNumber num2)
        {
            return "Компексні числа за значення не порівнюють!";
        }

        public static string operator <(ComplexNumber num1, ComplexNumber num2)
        {
            return "Компексні числа за значення не порівнюють!";
        }

        //task 2
        public static implicit operator string(ComplexNumber num1)
        {
            return "Дійсна частина = " + num1.real + "; Уявна частина = " + num1.imaginary;
        }

        //task 3
        public override string ToString()
        {
            return "Дійсна частина = " + real + "; Уявна частина = " + imaginary; ;
        }
    }

    class ComplexSet //task 4
    {
        ComplexNumber[] data;
        public ComplexSet()
        {
            data = new ComplexNumber[5];
        }

        //task 5
        public ComplexNumber this[int index]
        {
            get
            {
                return data[index];

            }
            set
            {
                data[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber num1 = new ComplexNumber(2, 45);
            string stringnum1 = num1;
            Console.WriteLine(stringnum1);

            ComplexNumber num2 = new ComplexNumber(1, 8);
            Console.WriteLine(num2.ToString());

            ComplexNumber num3 = new ComplexNumber(3, 7);
            ComplexNumber num4 = new ComplexNumber(5, -6);
            Console.WriteLine(num3 + num4);
            Console.WriteLine(num3 - num4);
            Console.WriteLine(num3 == num4);
            Console.WriteLine(num3 != num4);
            Console.WriteLine(num3 > num4);
            Console.WriteLine(num3 < num4);

            Console.ReadKey();
        }
    }
}