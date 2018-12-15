using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deyxtra
{
    class Program
    {
        public static List<Vershina> graf;
        public static Dictionary<char, int> distans = new Dictionary<char, int>();
        public static List<char> rout = new List<char>();
        static void Main(string[] args)
        {

            Init();

            string[,] temp = InitMassiv(graf);
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    Console.Write($"{temp[i, j],3}");
                }
                Console.WriteLine();
            }


            Vershina start = graf[0];
            Vershina fin = graf[4];


            Vershina.PrintGraf(graf);
            foreach (var item in graf)
            {
                Route.PrintRoute(item);
            }
            Console.WriteLine();

            Process(start,fin);

            Console.ReadKey();
        }


        /// <summary>
        /// преобразует граф в двумерный массив
        /// </summary>
        /// <param name="obj">граф</param>
        /// <returns>массив ходов графа</returns>
        private static string[,] InitMassiv(List<Vershina> obj)
        {
            string[,] mass = new string[obj.Count + 1, obj.Count + 1];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (i == 0 && j == 0) mass[i, j] = " ";
                    else if (i == 0) mass[i, j] = obj[j-1].name.ToString();
                    else if (j == 0) mass[i, j] = obj[i-1].name.ToString();
                }

            }

            for (int i = 1; i < mass.GetLength(1); i++)
            {
                foreach (var ver in graf)
                {
                    if (mass[i, 0] == ver.name.ToString())
                    {
                        foreach (var r in ver.route)
                        {
                            for (int j = 0; j < mass.GetLength(0); j++)
                            {
                                if (mass[i, 0] == mass[0, j]) mass[i, j] = " ";
                                else if (mass[0, j] == r.finish.ToString()) mass[i, j] = r.lenght.ToString();

                            }

                        }
                    }
                }
            }


            return mass;
        }

        /// <summary>
        /// Поик кратчайшего пути методом Деикстра
        /// </summary>
        /// <param name="start">точка начала</param>
        /// <param name="fin">точка финиша</param>
        private static void Process(Vershina start,Vershina fin)
        {
            Ochered<Vershina> ochered = new Ochered<Vershina>();
            start.step = 0;
            ochered.Push(start);
            foreach (var ver in graf)
                distans.Add(ver.name, int.MaxValue);
            distans[start.name] = 0;

            //Расчёт карты маршрутов
            while (ochered.tail - ochered.head != 0)
            {
                var goFrom = ochered.Pop();
                foreach(var ver in graf)
                {
                    if(ver.name==goFrom.name)
                    foreach(var r in ver.route)
                    {
                          foreach(var n in graf)
                          {
                                if (n.name == r.finish)
                                {
                                    if (n.step > r.lenght + goFrom.step)
                                    {
                                        n.step = r.lenght + goFrom.step;
                                        ochered.Push(n);
                                        break;
                                    }
                                    else break;
                                }
                                
                          }
                    }
                }
            }

            //Расчёт обратного пути
            rout.Add(fin.name);
            var current = fin;
            do
            {
                foreach (var ver in graf)
                {
                    if(current != start)
                    if (ver.name == current.name)
                    {
                        foreach (var p in ver.route)
                        {
                            foreach (var _p in graf)
                            {
                                if (_p.name == p.finish)
                                {
                                    if (current.step == _p.step + p.lenght)
                                    {
                                        rout.Add(_p.name);
                                        current = _p;
                                        break;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                }
            } while (current != start);

            //Печать маршрута
            rout.Reverse();
            Console.WriteLine($"Марштут из точки {start.name} в точку {fin.name}: {string.Join("->", rout)}");
        }

        /// <summary>
        /// Инициализация графа
        /// </summary>
        private static void Init()
        {
            graf = new List<Vershina>();

            graf.Add(new Vershina('A', new Route[] { new Route('A','B', 5), new Route('A', 'G', 9 ), new Route('A', 'F', 12 ) }));
            graf.Add(new Vershina('B', new Route[] { new Route('B', 'A', 5 ),new Route ( 'B','C', 8 ) }));
            graf.Add(new Vershina('C', new Route[] { new Route('C', 'B', 8 ), new Route('C', 'D', 2 ), new Route('C', 'E', 8 ), new Route('C', 'G', 4 ) }));
            graf.Add(new Vershina('D', new Route[] { new Route('D', 'C', 2 ), new Route('C','E', 7 )}));
            graf.Add(new Vershina('E', new Route[] { new Route('E', 'C', 8 ), new Route('E','D', 7 ),new Route ('E','F', 3 ) }));
            graf.Add(new Vershina('F', new Route[] { new Route('F', 'A', 12 ), new Route('F', 'G', 1),new Route ('F', 'E', 3 ) }));
            graf.Add(new Vershina('G', new Route[] { new Route('G', 'A', 9 ), new Route('G', 'C', 4 ), new Route('G', 'F', 1 ) }));

        }
    }
    
    /// <summary>
    /// Сущность вершина
    /// </summary>
    public class Vershina
    {
        public char name { get; }
        public bool finde { get; set; }
        public bool check { get; set; }
        public int step { get; set; }

        public Route[] route;

        /// <summary>
        /// Инициализация вершины
        /// </summary>
        /// <param name="name">Имя вершины</param>
        /// <param name="route">возможные маршруты</param>
        public Vershina(char name, Route[] route)
        {
            this.name = name;
            this.route = route;
            this.step = int.MaxValue;
        }

        /// <summary>
        /// выводит информацию о вершинах графа
        /// </summary>
        /// <param name="arg">Граф</param>
        public static void PrintGraf(List<Vershina> arg)
        {
            Console.WriteLine($"Вершины графа:");
            foreach (var item in arg)
            {
                Console.Write($"{item.name}; ");
            }
            Console.WriteLine();
        }


    }

    /// <summary>
    /// Класс маршрутов
    /// </summary>
    public class Route
    {
        /// <summary>
        /// возвращает вершину маршрута
        /// </summary>
        public char start { get; }
        /// <summary>
        /// Возвращает конец маршрута
        /// </summary>
        public char finish { get; }

        /// <summary>
        /// возвращает длинну маршрута
        /// </summary>
        public int lenght { get; }


        /// <summary>
        /// Инициализирует маршрут
        /// </summary>
        /// <param name="start">вершина начала пути</param>
        /// <param name="finish">вершина конца пути</param>
        /// <param name="lenght">длинна пути</param>
        public Route(char start, char finish, int lenght)
        {
            this.start = start;
            this.finish = finish;
            this.lenght = lenght;
        }

        /// <summary>
        /// Выводит информацию о маршрутах из верщины
        /// </summary>
        /// <param name="arg">вершина</param>
        public static void PrintRoute(Vershina arg)
        {
            Console.WriteLine($"Возможные маршруты из точки {arg.name}:");
            foreach (var r in arg.route) Console.Write($"{r.start}->{r.finish}, длинной {r.lenght}; ");
            Console.WriteLine();
        }

    }

    /// <summary>
    /// Сущность Очередь
    /// </summary>
    /// <typeparam name="T">тип элементов внутри очереди</typeparam>
    public class Ochered<T>
    {
        public int head;
        public int tail;

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
