using System;

//2. Найти максимальное из четырех чисел.Массивы не использовать.

namespace algoritmy_lesson1_2
{
    class Program
    {
        static Random r = new Random();
        static int a;
        static int b;
        static int c;
        static int d;

        static int temp;

        static void Main(string[] args)
        {
            Init();
            temp = (a > b) ? a : b;

            temp = (temp > c) ? temp : c;
            temp = (temp > d) ? temp : d;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}," +
                $" наибольшее число {temp}");
            Console.ReadKey();
        }

        /// <summary>
        /// Инициализирует числа
        /// </summary>
        static void Init()
        {
            a = r.Next(0, 101);
            b = r.Next(0, 101);
            c = r.Next(0, 101);
            d = r.Next(0, 101);
        }


    }
}
