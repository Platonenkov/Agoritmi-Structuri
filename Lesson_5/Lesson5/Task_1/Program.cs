using System;

namespace Task_1
{
    class Program
    {
        static Stack<int> stack;

        static void Main(string[] args)
        {
            stack = new Stack<int>();

            Init();


        }
        /// <summary>
        /// Инициализация данных
        /// </summary>
        private static void Init()
        {
            bool flag;
            int N;
            int system = 2;

            while (true)
            {
                flag = false;
                while (!flag)
                {
                    Console.WriteLine("Введите число для преобразования");
                    flag = int.TryParse(Console.ReadLine(), out N);
                    if (!flag) Console.WriteLine("Введено не число");
                    else Console.WriteLine(Convert(N, system, stack));

                }
            }
        }

        /// <summary>
        /// Конвертор
        /// </summary>
        /// <param name="N">число</param>
        /// <param name="system">система счисления в которую переводим</param>
        /// <param name="stack">стек данных</param>
        /// <returns>строковое число</returns>
        static string Convert(int N, int system ,Stack<int> stack)
        {
            int temp = 0;
            string stroka = string.Empty;
            while (N != 0)
            {
                stack.Push(N % system);
                N = N / system;
                temp++;
            }

            while (temp > 0)
            {
                stroka = stroka + stack.Pop();
                temp--;
            }
            return stroka;
        }

    }

    /// <summary>
    /// Класс Стек
    /// </summary>
    /// <typeparam name="T">тип</typeparam>
    public class Stack<T>
    {
        int position;
        T[] data = new T[100];
        /// <summary>
        /// Кладет данные в стек
        /// </summary>
        /// <param name="obj">данные для внесения</param>
        public void Push(T obj) { data[position++] = obj; }
        /// <summary>
        /// забирает данные из стека
        /// </summary>
        /// <returns>данные</returns>
        public T Pop()
        {
                return data[--position];

            //if (position != -1)
            //    return data[--position];
            //else
            //{
            //    Console.WriteLine("Стек пуст");
            //    return data[99];
            //}

        }
    }
}
