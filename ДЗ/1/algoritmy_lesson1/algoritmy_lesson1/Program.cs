using System;


//1. Ввести вес и рост человека.
//Рассчитать и вывести индекс массы тела по формуле
//    I=m/(h* h); где
//m-масса тела в килограммах, h - рост в метрах.

namespace algoritmy_lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            int m=0;
            int h=0;
            bool flag = false;
            Console.WriteLine("Расчёт индекса массы тела");
            Console.WriteLine("введите массу тела в килограммах");

            while (!flag)
            {
                if (int.TryParse(Console.ReadLine(), out m)) flag = true;
                else Console.WriteLine("Введите число");
            }
            flag = false;
            Console.WriteLine("введите рост в метрах");
            while (!flag)
            {
                if (int.TryParse(Console.ReadLine(), out h)) flag = true;
                else Console.WriteLine("Введите число");
            }
            Console.WriteLine($"ИМТ = {m / (h * h)}");
            Console.ReadKey();
        }

    }
}
