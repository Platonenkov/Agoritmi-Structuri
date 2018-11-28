using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static int[] mass;
        static int[] mass_puz;
        static int[] mass_sheik;
        static int[] mass_vst;
        static Random random = new Random();

        static double timer_1;
        static double timer_2;
        static double timer_3;

        static long count_1;
        static long count_2;
        static long count_3;

        static void Main(string[] args)
        {
            //Init(100);
            //Print(mass);
            //Console.WriteLine();
            //Puz(mass_puz);
            //Print(mass_puz);
            //Console.WriteLine();
            //Sheiker(mass_sheik);
            //Print(mass_sheik);
            //Console.WriteLine();
            //Vstavka(mass_vst);
            //Print(mass_vst);
            //Console.WriteLine($"\n{count_1,5}{count_2,5}{count_3,5}");

            long a = 1000;
            long b = 10000;
            long c = 100000;

            Init(a);
            Puz(mass_puz);
            Sheiker(mass_sheik);
            Vstavka(mass_vst);
            PritnResalt(a);

            Init(b);
            Puz(mass_puz);
            Sheiker(mass_sheik);
            Vstavka(mass_vst);
            PritnResalt(b);

            Init(c);
            Puz(mass_puz);
            Sheiker(mass_sheik);
            Vstavka(mass_vst);
            PritnResalt(c);

            Console.ReadKey();
        }

        /// <summary>
        /// Инициализация массива и его копий
        /// </summary>
        static void Init(long N)
        {
            mass = new int[N];
            for (int i = 0; i < N; i++)
                mass[i] = random.Next(0, 100);
            mass_sheik = new int[N];
            mass_puz = new int[N];
            mass_vst = new int[N];

            Array.Copy(mass, mass_sheik, N);
            Array.Copy(mass, mass_puz, N);
            Array.Copy(mass, mass_vst, N);
        }

        /// <summary>
        /// Обмен чисел местами
        /// </summary>
        /// <param name="a">число 1</param>
        /// <param name="b">число 2</param>
        static void Swap(ref int a, ref int b, ref long count)
        {
            int t = a;
            a = b;
            b = t;
            count++;
        }

        /// <summary>
        /// Инициализирует Шейкерную сортировку массива
        /// </summary>
        /// <param name="m">массив</param>
        static void Puz(int[] m)
        {
            count_1 = 0;
            DateTime date_start = DateTime.Now;
            for(int i = 0; i < m.Length; i++)
            {
                for(int j = 0; j < m.Length - 1; j++)
                {
                    if (m[j] > m[j + 1]) Swap(ref m[j], ref m[j + 1],ref count_1);
                }
            }
            timer_1 = (DateTime.Now - date_start).TotalMilliseconds;
        }

        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="m">массив</param>
        static void Sheiker(int[] m)
        {
            DateTime date_start = DateTime.Now;
            int i_left = 0;
            int i_right = m.Length - 1;
            count_2 = 0;

            while(i_left<i_right)
            {
                Go_right(m, i_left,i_right);
                i_right--;
                Go_left(m, i_left, i_right);
                i_left++;
            }

            timer_2 = (DateTime.Now - date_start).TotalMilliseconds;
        }
        /// <summary>
        /// Шейкерная сортировка проход справа налево
        /// </summary>
        /// <param name="m">массив</param>
        /// <param name="start">левый флаг</param>
        /// <param name="end">правый флаг</param>
        static void Go_left(int[] m, int start, int end)
        {
            for (int j = end; j > start; j--)
            {
                if (m[j] < m[j - 1]) { Swap(ref m[j], ref m[j - 1], ref count_2); }
            }
        }

        /// <summary>
        /// Шейкерная сортировка проход слева направо
        /// </summary>
        /// <param name="m">массив</param>
        /// <param name="start">левый флаг</param>
        /// <param name="end">правый флаг</param>
        static void Go_right(int[] m, int start, int end)
        {
            for (int j = start; j < end; j++)
            {
                if (m[j] > m[j + 1]) { Swap(ref m[j], ref m[j + 1],ref count_2); }
            }
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="m">массив</param>
        static void Vstavka(int[] m)
        {
            DateTime date_start = DateTime.Now;
            count_3 = 0;
            for (int i = 0; i < m.Length; i++)
            {
                int temp = m[i];
                int j = i;
                while(j>0&& m[j - 1] > temp)
                {
                    Swap(ref m[j], ref m[j - 1], ref count_3);
                    j--;
                }
            }

            timer_3 = (DateTime.Now - date_start).TotalMilliseconds;
            
        }

        /// <summary>
        /// Выводит на экран массив
        /// </summary>
        /// <param name="m">массив</param>
        static void Print(int[] m)
        {
            foreach (int e in m) Console.Write($"{e} ");
        }

        static void PritnResalt(long a)
        {
            Console.WriteLine($"Сортировка Пузырьком\nАсимптотическая: {a * a}\nТочная:{a*a-a}\nФактическая{count_1}");
            Console.WriteLine($"Сортировка Шейкерная\nАсимптотическая: {a * a}\nТочная:{a * a - a}\nФактическая{count_2}");
            Console.WriteLine($"Сортировка Вставками\nАсимптотическая: {a * a}\nТочная:{a * a - a}\nФактическая{count_3}");
        }

    }
}
