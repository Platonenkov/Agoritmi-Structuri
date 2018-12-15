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

            //Sort_by_Counting(mass_1);

            Quick_sort(mass_1);

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

        public static void Quick_sort(int[] mass)
        {
            int[] temp = new int[mass.Length];
            Array.Copy(mass, temp, mass.Length);
            temp = Quick_sort(mass, mass[0], mass[mass.Length-1]);

            foreach (var item in temp)
            {
                Console.Write($"{item}  ");
            }

        }

        public static int[] Quick_sort(int[] mass, int v1, int v2)
        {
            int flag = mass.Length / 2;
            for (int i = v1; i <= flag; i++)
            {
                if (mass[i] >= mass[flag]) Swap(ref mass[i], ref mass[flag]);
            }
            for (int i = flag+1; i < v2; i++)
            {
                if (mass[i]<mass[flag]) Swap(ref mass[i], ref mass[flag]);
            }
            Quick_sort(mass, v1, flag - 1);
            Quick_sort(mass, flag + 1, v2);
            return mass;
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
