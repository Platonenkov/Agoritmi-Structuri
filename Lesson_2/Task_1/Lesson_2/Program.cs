using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = 2;
            int temp = 0;
            int system = 2;

            while (N > 0)
            {
                temp = temp + N % system;
                N = N / 10;

            }
            Console.Write(temp);
        }
    }
}
