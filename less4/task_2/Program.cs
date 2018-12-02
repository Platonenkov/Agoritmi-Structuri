// Платоненков задача 2


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {



        static void Main(string[] args)

        {
            int i = 0;
            int j = 0;
            string word1 = "geekbrains";
            string word2 = "geekminds";
            string[] mwords1 = new string[word1.Length];
            for (i = 0; i < mwords1.Length; i++)
            {
                mwords1[i] = word1[i].ToString();
            }
            string[] mwords2 = new string[word2.Length];
            for (i = 0; i < mwords2.Length; i++)
            {
                mwords2[i] = word2[i].ToString();
            }


            int s1 = word1.Length + 2;
            int s2 = word2.Length + 2;

            string[,] matrix = new string[s2, s1];
            for (i = 2; i < s1; i++)
            {
                matrix[0, i] = mwords1[i - 2];
            }
            for (i = 2; i < s2; i++)
            {
                matrix[i, 0] = mwords2[i - 2];
            }


            int count = 0;
            i = 1;
            j = 1;
            PrintMatrix(matrix, s2, s1);

            SetMap(i, j, count, matrix, s2, s1);
            PrintMatrix(matrix, s2, s1);
            Console.ReadKey();

        }

        static void SetMap(int i, int j, int count, string[,] matrix, int s2, int s1)
        {
            int step = (s1 < s2) ? s1 : s2;
            matrix[0, 0] = " ";
            matrix[0, 1] = " ";
            matrix[1, 0] = " ";
            int iTemp;
            int jTemp;
            int tempCount = count;
            for (i = 1; i < s2; i++)
            {
                iTemp = i;

                for (j = 1; j < s1; j++)
                {
                    jTemp = j;
                    if (matrix[i, j] is null)
                    {                       
                        if (i == 1 || j == 1)
                        {
                            matrix[i, j] = 0.ToString();
                        }
                        else
                        {

                            if (matrix[i, 0] == matrix[0, j]) // Буквы совпали
                            {
                                if (matrix[i,j-1]==count.ToString()) // счетчик не менялся
                                {
                                    count++;
                                    while (j < s1) // заполняем строку
                                    {
                                        matrix[i, j] = count.ToString();
                                            j++;
                                    }
                                    while (iTemp < s2) // заполняем столбец
                                    {
                                        matrix[iTemp, jTemp] = count.ToString();
                                        iTemp++;
                                    }

                                }
                                else
                                {
                                    matrix[iTemp, jTemp] = count.ToString(); 

                                }

                            }
                            else 
                            {
                                if (matrix[i, j - 1] == count.ToString())
                                {
                                    matrix[i, j] = count.ToString();

                                }
                                else if (matrix[i-1,j]==count.ToString())
                                {
                                    while (iTemp < s2) // заполняем столбец
                                    {
                                        matrix[iTemp, jTemp] = count.ToString();
                                        iTemp++;
                                    }
                                }
                                else
                                {
                                    matrix[i, j] = matrix[i, j - 1];
                                }
                            }

                        }

                    }
                }
            }
        }

        static void PrintMatrix(string[,] matrix, int s2, int s1)
        {
            for (int i = 0; i < s2; i++)
            {
                for (int j = 0; j < s1; j++)
                {
                    Console.Write(matrix[i, j] + " ");

                }
                Console.WriteLine();
            }

        }
    }
}
