using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            int N;
            string temp = string.Empty;
            int system = 2;

            while (true)
            {
                flag = false;
                while (!flag)
                {
                    Console.WriteLine("Введите число для преобразования");
                    flag = int.TryParse(Console.ReadLine(), out N);
                    if (!flag) Console.WriteLine("Введено не число");
                    else Console.WriteLine(Convert(N, system, temp));

                }
            }
        }

        static string Convert(int N, int system, string temp)
        {
            if (N == 0) return ReversNumber(temp);
            return temp=Convert(N/system, system, temp=temp+N%system).ToString();
        }

        static string ReversNumber(string stroka)
        {
            char[] s = stroka.ToCharArray();
            if (s.Length < 4)
            {
                int temp = 4 - s.Length;
                while (temp > 0)
                {
                    stroka = stroka + "0";
                    temp--;
                }
            }
            else stroka = string.Empty;

            for (int i = s.Length-1; i >= 0; i--)
            {
                stroka = stroka + s[i];
            }
            return stroka;
        }
    }

}
