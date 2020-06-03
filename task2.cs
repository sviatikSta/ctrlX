/*Напишіть програму, в якій оголошується делегат для методів з символьним
аргументом, які не повертають результат.Опишіть клас, в якому має бути
символьне поле і метод, що дозволяє привласнити значення символьному
полю об'єкта. У методу один символьний аргумент і метод не повертає
результат.Створіть масив об'єктів даного класу. Створіть екземпляр делегата.
У список викликів цього делегата необхідно додати посилання на метод
(привласнює значення символьному полю) кожного об'єкта з масиву.
Перевірити результат виклику такого примірника делегата.*/
using System;

namespace Delegate2
{
    public delegate void Delegate1(char sym);

    class Test
    {
        private char symbol;

        public void Init(char sym)
        {
            symbol = sym;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test[] array = new Test[5];
            array[0] = new Test();
            array[1] = new Test();
            array[2] = new Test();
            array[3] = new Test();
            array[4] = new Test();

            Delegate1 sym1 = array[0].Init;
            Delegate1 sym2 = array[1].Init;
            Delegate1 sym3 = array[2].Init;
            Delegate1 sym4 = array[3].Init;
            Delegate1 sym5 = array[4].Init;

            sym1('q');
            sym2('w');
            sym3('e');
            sym4('r');
            sym5('t');
        }
    }
}
