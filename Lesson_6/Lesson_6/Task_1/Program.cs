using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static string hashString = string.Empty;
        static Random r = new Random();
        static int count = 20;

        static void Main(string[] args)
        {
            string stroka = "hello world";
            
            HashFunction(stroka);
            Console.WriteLine(hashString);

            Console.ReadKey();
        }

        private static void HashFunction(string stroka)
        {
            int[] temp = new int[stroka.Length];
            int i = 0;
            foreach (var item in stroka)
            {
                temp[i++] = (int)item;
                
            }
            for (int j = 0; j < temp.Length; j++)
            {
                if (hashString.Length == count) break;
                if (j < count && j % 2 == 0) { hashString = hashString + (char)Math.Abs(temp[j] / (j + 1)); }
                if (hashString.Length < count) { hashString = hashString + (char)Math.Abs(temp[j / 2]);}

            }

            //while (hashString.Length < count)
            //{
            //    hashString = hashString + (char)(temp[r.Next(0, temp.Length - 1)]*2);
            //}


        }


    }
}
