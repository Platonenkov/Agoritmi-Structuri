using System;

namespace task_12
{
    class Program
    {
        //12. Написать функцию нахождения максимального из трех чисел.
        static void Main(string[] args)
        {
            int x1;
            int x2;
            int x3;
            Console.WriteLine("Программа поиска наибольшего числа из трёх");

            Console.WriteLine("Введите первое число");
            x1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            x2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите третье число");
            x3 = Int32.Parse(Console.ReadLine());
            if (x1 > x2)
            {
                if (x1 > x3)
                {
                    Console.WriteLine("Первое введенное число больше");

                }
                else
                {
                    Console.WriteLine("Третье число больше");
                }
            }
            else
            {
                if (x2 > x3)
                {
                    Console.WriteLine("Второе число больше");

                }
                else
                {
                    Console.WriteLine("Третье число больше");
                }

            }
            Console.ReadLine();
        }
    }
}
