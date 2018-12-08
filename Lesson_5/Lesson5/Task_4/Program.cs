using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Ochered<int> test = new Ochered<int>();
            test.Push(10);
            test.Push(5);
            test.Push(2);
            Console.WriteLine(test.Pop());
            Console.WriteLine(test.Pop());
            test.Push(6);
            Console.WriteLine(test.Pop());

        }
    }
    /// <summary>
    /// Класс очередь
    /// </summary>
    /// <typeparam name="T">тип очереди</typeparam>
    public class Ochered<T>
    {
        int head;
        int tail;

        T[] data = new T[100];
        /// <summary>
        /// Кладет данные в очередь
        /// </summary>
        /// <param name="obj">данные для внесения</param>
        public void Push(T obj)
        {
            data[tail++] = obj;
        }
        /// <summary>
        /// забирает данные из очереди
        /// </summary>
        /// <returns>данные</returns>
        public T Pop()
        {
            return data[head++];

        }


    }
}
