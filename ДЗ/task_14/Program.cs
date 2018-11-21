using System;

namespace task_14
{

//    14. * Автоморфные числа.Натуральное число называется автоморфным, если оно равно последним
//цифрам своего квадрата.Например, 25 \ :sup: `2` = 625. Напишите программу, которая вводит
//натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            long N = r.Next(100, 100000);

            for (int i = 25; i <= N; i++)
            {
                if (i * i <= N)
                {
                    var temp=i*i;
                    var res=0;
                    while(temp>0)
                    {
                        res =res+temp % 10;
                        if (res == i)
                        {
                            Console.Write(i + ", ");
                            break;
                        }
                        temp = temp / 10;
                        res = res * 10;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Данные числа в диапозоне от 1 до {N} являются автоморфными");
            Console.ReadKey();

        }
    }
}
