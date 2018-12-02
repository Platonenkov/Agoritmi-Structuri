// Платоненков
// Задача 1, доступ по карте достпа с препятствиями (препятствия генерируются автоматически)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platonenkov
{
    namespace less4
    {
        class Program
        {
            
            static void Main()
            {
                int check = 1;
                Console.WriteLine("Карта доступа строится автоматически, 1 - доступ, 0 - нет доступа");
                while (check != 0)
                    {
                    int n = 10; // число строк
                    int m = 10; // Число столбцов
                    int[,] map = new int[n, m]; // Карта решения
                    int[,] tryMap = new int[n, m]; // карта доступа

                    TryMap(n, m, tryMap);

                    int i, j;

                    for (j = 0; j < m; j++)
                    {
                        if (j == 0)
                        {
                            map[0, j] = (tryMap[0, j] == 0) ? 0 : 1;
                        }
                        else
                        {
                            if (tryMap[0, j] == 1)
                            {
                                if (map[0, j - 1] != 0)
                                    map[0, j] = 1; // первая строка с единицами
                            }
                            else
                            {

                                map[0, j] = 0; // первая строка если в ней встречается 0
                            }
                        }
                    }
                    for (i = 1; i < n; i++)
                    {
                        if (tryMap[i, 0] != 0)
                        {
                            if (map[i - 1, 0] != 0)
                            {
                                map[i, 0] = 1; // первый столбец с единицами
                            }
                            else
                            {
                                map[i, 0] = 0; // первый столбец с нулями если выше ноль
                            }
                        }
                        else
                        {
                            map[i, 0] = 0; // первый столбец с нулями если выше ноль
                        }

                        for (j = 1; j < m; j++)
                        {
                            map[i, j] = (tryMap[i, j] == 1) ? map[i, j - 1] + map[i - 1, j] : 0;
                        }

                    }

                    Console.WriteLine("\n\n\nКарта решения количества ходов:");
                    PrintMaP(n, m, map);
                    Console.Write("\n\nВведите 0 чтобы закончить, введите другое число чтобы создать новую карту доступа: ");
                    check = int.Parse(Console.ReadLine());
                }

            }

            static void TryMap (int n, int m, int[,] tryMap)
            {
                int can;
                Random rand = new Random();
                
                int i, j;
         
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        can = rand.Next(0, 10);
                        if (can > 1)
                        {
                            tryMap[i, j] = 1;
                        }
                        else if (can <= 1)
                        {
                            tryMap[i, j] = 0;
                        }
                    }
                    
                }
                tryMap[0, 0] = 1;

                //Выводим карту
                Console.WriteLine("\n\n\nКарта доступа:");
                PrintMaP(n, m, tryMap);
                //for (i = 0; i < n; i++)
                //{
                //    for (j = 0; j < m; j++)
                //    {
                //       Console.Write($"{tryMap[i, j]}    ");

                //    }
                //    Console.WriteLine();
                //}

            }


            static void PrintMaP(int n, int m, int[,] map)
            {
                string S = "X";
                int i, j;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        if (map[i, j] == 0)
                        {                            
                            Console.Write($"{S,5}");
                            continue;
                        }
                        Console.Write($"{map[i, j], 5}");
                    }
                    Console.WriteLine();

                }

            }

        }
    }
}
