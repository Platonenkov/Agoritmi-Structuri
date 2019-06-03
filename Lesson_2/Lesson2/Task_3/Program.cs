using System;
using System.Collections.Generic;

//3. ** Исполнитель «Калькулятор» преобразует целое число, записанное на экране.У
// исполнителя две команды, каждой присвоен номер:
//1. Прибавь 1.
//2. Умножь на 2.
//Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза.Сколько
//существует программ, которые число 3 преобразуют в число 20:
//а.С использованием массива.
//b. * С использованием рекурсии.
namespace Task_3
{
    class Program
    {
       static int N;
        static int DigitForFind;
        static int[] mas ;

        static void Main(string[] args)
        {
            N = 3;
            DigitForFind = 20;
            mas = new int[DigitForFind+1];
            mas.Initialize();

            //Рекурсивное решение
            Console.WriteLine("Решение Рекурсией "+Recurse(DigitForFind));

            //Массивом
            Console.WriteLine("Решение массивом " + InMassiv());
            Console.ReadKey();
        }

        /// <summary>
        /// решение массивом
        /// </summary>
        /// <returns></returns>
        static int InMassiv()
        {
            mas[N] = 1;
            for(int i = N+1; i <= DigitForFind; i++)
            {
                if (i % 2 == 0) mas[i] = mas[i - 1] + mas[i / 2];
                else mas[i] = mas[i - 1];
            }
            return mas[DigitForFind];


        }

        /// <summary>
        /// Решение Рекурсией
        /// </summary>
        /// <param name="n">Число в которое нужно прийти</param>
        /// <returns></returns>
        static int Recurse(int n)
        {
            if (n == N) return 1;
            else if (n % 2 == 0 && n / 2 >= N) return Recurse(n / 2) + Recurse(n - 1);
            else return Recurse(n - 1);
        }
    }
}
