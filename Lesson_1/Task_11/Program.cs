using System;

namespace Task_11
{
    class Program
    {
        //        11. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать среднее арифметическое всех
        //положительных четных чисел, оканчивающихся на 8.
        static void Main(string[] args)
        {
            Console.WriteLine("Подсчёт средне арифметического всех положительных чисел, оканчивающихся на 8");
            Console.WriteLine("Введите числа поочереди, введите 0 чтобы закончить ввод");
            int[] numbers = new int[100];
            int i = 0;
            int a;
            int count = 0;
            int sum = 0;

            while ((a = Int32.Parse(Console.ReadLine())) != 0)
                if (a > 0 & a % 2 == 0)
                {
                    if (a % 10 == 8)
                    {
                        numbers[i++] = a;
                        count++;
                    }
                }
            foreach (int value in numbers)
            {
                sum = sum + value;
            }

            Console.WriteLine("среднеарифметическое равно = " + sum / count);
            Console.WriteLine("Нажмите ввод чтобы продолжить");
            Console.ReadLine();
        }
    }
}
