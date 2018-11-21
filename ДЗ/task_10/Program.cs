using System;

namespace task_10
{
//    10. Дано целое число N(> 0). С помощью операций деления нацело и взятия остатка от деления
//определить, имеются ли в записи числа N нечетные цифры.Если имеются, то вывести True, если нет
//— вывести False.
    class Program
    {
        static void Main(string[] args)
        {
            long N;
            bool flag;

            while (true)
            {
                flag = false;
                if (!long.TryParse(Console.ReadLine(), out N))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    while (N > 0)
                    {
                        if (N % 2 != 0) flag = true;
                        N = N / 10;
                    }

                }
                Console.WriteLine(flag);
                
            }

        }
    }
}
