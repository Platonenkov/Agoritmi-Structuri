using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    //public class Sorting
    //{
    //    int a { get; set; }//Размерность массива
    //    string name { get; set; } // имя массива
    //    int[] mass { get; set; } // Массив
    //    public Sorting(int[]mass, int a, string name)
    //    {
    //        this.mass = mass;
    //        this.a = a;
    //        this.name = name;
    //    }
    //}

    class Program
    {
       // static List<Sorting> ListMassivov = new List<Sorting>();
        static Random r = new Random();
        static int a = 100;
        static int b = 10000;
        static int c = 1000000;
        static int[] mass_1;
        static int[] mass_2;
        static int[] mass_3;

        static void Main(string[] args)
        {
            Start();

            Sort_by_Counting(mass_1);

            //Quick_sort(mass_1);

            //Console.WriteLine(string.Join(" ", Sort_by_Sliyanie(mass_1)));

            Console.ReadKey();
        }

        /// <summary>
        /// Начало работы программы
        /// </summary>
        public static void Start()
        {
            mass_1 = new int[a];
            mass_2 = new int[b];
            mass_3 = new int[c];


            InitMassiv(mass_1);
            InitMassiv(mass_2);
            InitMassiv(mass_3);

        }

        /// <summary>
        /// Инициализирует массив случайными числами
        /// </summary>
        /// <param name="mass">массив</param>
        public static void InitMassiv(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = r.Next(0, 100);
            }
        }

        /// <summary>
        /// сортировка подсчётом
        /// </summary>
        /// <param name="mass">массив для сортировки</param>
        public static void Sort_by_Counting(int[] mass)
        {
            int[] temp = new int[mass.Length];
            Array.Copy(mass, temp, mass.Length);
            int[] temp_2 = new int[temp.Max()+1];
            for (int i = 0; i < temp.Length; i++)
            {
                temp_2[temp[i]]++;
            }
            int counter = 0;
            for (int i = 0; i < temp_2.Length; i++)
            {
                int count = temp_2[i];
                while (count > 0) { temp[counter++] = i; count--; }
            }

            foreach (var item in temp)
            {
                Console.Write($"{item}  ");
            }
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="mass">массив данных</param>
        public static void Quick_sort(int[] mass)
        {
            int[] temp = new int[mass.Length];
            Array.Copy(mass, temp, mass.Length);
            temp = Quick_sort(mass, 0, mass.Length-1);

            foreach (var item in temp)
            {
                Console.Write($"{item}  ");
            }

        }


        /// <summary>
        /// Сортировка Хоара
        /// </summary>
        /// <param name="mass">массив данных</param>
        /// <param name="first">индекс первого значения</param>
        /// <param name="last">индекс последнего значения</param>
        /// <returns></returns>
        public static int[] Quick_sort(int[] mass, int first, int last)
        {
            int i = first, j = last, x = mass[(first + last) / 2];

            do
            {
                while (mass[i] < x)
                    i++;
                while (mass[j] > x)
                    j--;
                if (i <= j)
                {
                    if (mass[i] > mass[j])
                    {
                        Swap(ref mass[i], ref mass[j]);
                    }
                    i++;
                    j--;
                }
            } while (i <= j);
            if (i < last)
                Quick_sort(mass, i, last);
            if (first < j)
                Quick_sort(mass, first, j);
            return mass;
        }

        /// <summary>
        /// Сортировка слиянием
        /// </summary>
        /// <param name="mass">массив для сортировки</param>
        /// <returns>отсортированный массив</returns>
        public static int[] Sort_by_Sliyanie(int[] mass)
        {
            if (mass.Length == 1)
                return mass;
            int mid_point = mass.Length / 2;
            return merge(Sort_by_Sliyanie(mass.Take(mid_point).ToArray()), Sort_by_Sliyanie(mass.Skip(mid_point).ToArray()));
        }
        /// <summary>
        /// Слияние двух массивов
        /// </summary>
        /// <param name="mass1">массив 1</param>
        /// <param name="mass2">массив 2</param>
        /// <returns>объединенный массив</returns>
        public static int[] merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b] && b < mass2.Length)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }

        /// <summary>
        /// Обмен данными
        /// </summary>
        /// <param name="a">значение 1</param>
        /// <param name="b">значение 2</param>
        public static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}
