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

            long N = 70000;
            long i = 0;
            while(i<N)
            {
                    long temp=i*i;
                    long res=0;
                int cout = 0;
                long temp_i = i;
                while (temp_i > 0)
                {
                    temp_i = temp_i / 10;
                    cout++;
                }
                        while (cout>0)
                        {
                            res = res * 10;
                            res = res + temp % 10;
                            temp = temp / 10;
                        cout--;
                        }
                        temp = 0;
                while (temp < i && i % 10 != 0)
                            {
                                temp = temp * 10;
                                temp = temp + res % 10;
                                res = res / 10;
                            }
                if (temp == i && i % 10 != 0) Console.Write(i + " ");
                    i++; 
            }
            Console.WriteLine();
            Console.WriteLine($"Данные числа в диапозоне от 1 до {N} являются автоморфными");
            Console.ReadKey();

        }
    }
}
