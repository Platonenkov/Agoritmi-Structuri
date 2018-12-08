using System;

namespace Task_2
{
    class Program
    {
        static string stroka;
        static Stack<int> numbers = new Stack<int>();
        static Stack<char> syvolOperator = new Stack<char>();
        static Stack<char> bracket = new Stack<char>();
        static Stack<char> checkBraket = new Stack<char>();

        static Ochered<char> openBracket = new Ochered<char>();
        static Ochered<char> closingBracket = new Ochered<char>();

        static char clbracket;

        static void Main(string[] args)
        {
            stroka = "[2*{5*(4+7)}]";
            int rez;
            bool Proverka = Check(stroka);
            if (Proverka == true)
            {
              rez = OperationProces(stroka);
                Console.WriteLine($"Результат выражения {stroka} = {rez}");
            }
            else Console.WriteLine("Введены неверные данные, расставьте скобки правильно");

            Console.ReadKey();
        }

        /// <summary>
        /// Решение формулы
        /// </summary>
        /// <param name="stroka">формула в строчном представлении</param>
        private static int OperationProces(string stroka)
        {
            Stack<char> formula = new Stack<char>();
            var mass = stroka.ToCharArray();
            int count = stroka.Length;
            clbracket = closingBracket.Pop();

            for (int i = mass.Length-1; i >=0; i--)
            {
                if (ClosingBracket(mass[i]))
                {
                    formula.Push(mass[i]);
                    continue;
                }
                if (char.IsDigit(mass[i]))
                {
                    formula.Push(mass[i]);
                    continue;
                }
                if (IsOperator(mass[i]))
                {
                    formula.Push(mass[i]);
                    continue;
                }
                if (OpenBracket(mass[i],clbracket))
                {
                    ProcessOperation(formula);
                    continue;
                }
            }
            Stack<char> s = new Stack<char>();

            while (formula.count > 0)
            {
               s.Push(formula.Pop());
            }

            string temp = string.Empty;
            while (s.count > 0)
            {
                temp = temp + s.Pop();

            }
            return int.Parse(temp);

        }


        /// <summary>
        /// решение части стека внутри скобок
        /// </summary>
        /// <param name="formula">стек символов</param>
        private static void ProcessOperation(Stack<char> formula)
        {
            string a = string.Empty;
            char simvol=' ';
            string b = string.Empty; ;

            var temp = formula.Pop();
            while (!ClosingBracket(temp))
            {
                if (a == string.Empty)
                    a = temp.ToString();
                    while (true)
                    {
                        var temp1 = formula.Pop();
                        if (char.IsDigit(temp1))
                        {
                            a = a + temp1;
                        }
                        else if (IsOperator(temp1)) { simvol = temp1; break; }
                    }
                if (b == string.Empty)
                    while (true)
                    {
                        var temp1 = formula.Pop();
                        if (char.IsDigit(temp1))
                        {
                            b = b + temp1;
                        }
                        else if (ClosingBracket(temp1)) { temp = temp1; clbracket = closingBracket.Pop(); break; }
                    }
            }

                Operation(a, simvol, b, formula);
            
        }

        /// <summary>
        /// Выполнение операции над переменными
        /// </summary>
        /// <param name="a">левая переменная</param>
        /// <param name="simvol">символ операции</param>
        /// <param name="b">правая переменная</param>
        /// <param name="formula">часть формулы на текущее выполнение</param>
        private static void Operation(string a, char simvol, string b, Stack<char> formula)
        {
            char[] temp;
            string s = string.Empty;
            if (simvol == '*') s = (int.Parse(a) * int.Parse(b)).ToString();
            else if (simvol == '/') s = (int.Parse(a) / int.Parse(b)).ToString();
            else if (simvol == '-') s = (int.Parse(a) - int.Parse(b)).ToString();
            else if (simvol == '+') s = (int.Parse(a) + int.Parse(b)).ToString();
            temp = s.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                formula.Push(temp[i]);
            }

        }

        /// <summary>
        /// проверка символов и распределение по стекам
        /// </summary>
        /// <param name="stroka"></param>
        private static bool Check(string stroka)
        {
            var mass = stroka.ToCharArray();
            int count = mass.Length;
            int i = -1;

            while (count > 0)
            {
                i++;
                count--;
                if (char.IsDigit(mass[i])) numbers.Push(int.Parse(mass[i].ToString()));
                if (IsBracket(mass[i])) bracket.Push(mass[i]);
                if (IsOperator(mass[i])) syvolOperator.Push(mass[i]);
            }
            return CheckBracket(bracket);
        }

        /// <summary>
        /// Проверка правильности расстановки скобок
        /// </summary>
        /// <param name="bracket">массив скобок</param>
        /// <returns>истина или лож</returns>
        private static bool CheckBracket(Stack<char> bracket)
        {

            while (bracket.count > 0)
            {
                var temp = bracket.Pop();
                if (ClosingBracket(temp)) continue;
                else if (OpenBracket(temp)) continue;
                else return false;

            }
            return true;
        }

        /// <summary>
        /// Проверяет явлется ли скобка открывающей
        /// </summary>
        /// <param name="v">символ</param>
        /// <returns>истина или лож</returns>
        private static bool OpenBracket(char v)
        {
            var temp = (v == '(') ? ')' : (v == '{') ? '}' : ']';
            if (!(checkBraket.count == 0) && temp.Equals(checkBraket.Pop())) return true;
            return false;
        }
        /// <summary>
        /// Сверяет явлется ли скобка открывающей
        /// </summary>
        /// <param name="v">сверяемый символ</param>
        /// <param name="clbracket">символ с которым сверяемся</param>
        /// <returns>истина или лож</returns>
        private static bool OpenBracket(char v, char clbracket)
        {
            var temp = (v == '(') ? ')' : (v == '{') ? '}' : ']';
            if (temp.Equals(clbracket)) return true;
            return false;
        }

        /// <summary>
        /// Проверяет является ли скобка закрывающейся
        /// </summary>
        /// <param name="v">символ</param>
        /// <returns>истина или лож</returns>
        private static bool ClosingBracket(char v)
        {
            if (v.Equals('}')) { checkBraket.Push(v); return true; }
            if (v.Equals(')')) { checkBraket.Push(v); return true; }
            if (v.Equals(']')) { checkBraket.Push(v); return true; }
            return false;
        }


        /// <summary>
        /// Проверяет является ли символ оператором
        /// </summary>
        /// <param name="v">символ</param>
        /// <returns>истина или ложь</returns>
        private static bool IsOperator(char v)
        {
            if (v.Equals('-')) return true;
            if (v.Equals('+')) return true;
            if (v.Equals('*')) return true;
            if (v.Equals('/')) return true;
            if (v.Equals('=')) return true;
            if (v.Equals('^')) return true;
            if (v.Equals('%')) return true;
            return false;
        }

        /// <summary>
        /// Проверяет является ли символ скобкой
        /// </summary>
        /// <param name="v">символ</param>
        /// <returns>истина или ложь</returns>
        private static bool IsBracket(char v)
        {
            if (v.Equals('{')) { openBracket.Push(v); return true; }
            if (v.Equals('}')) { closingBracket.Push(v); return true; }
            if (v.Equals('(')) { openBracket.Push(v); return true; }
            if (v.Equals(')')) { closingBracket.Push(v); return true; }
            if (v.Equals('[')) { openBracket.Push(v); return true; }
            if (v.Equals(']')) { closingBracket.Push(v); return true; }
            return false;
        }

        /// <summary>
        /// Класс Стек
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        public class Stack<T>
        {
            int position;
            public int count = 0;

            T[] data = new T[100];
            /// <summary>
            /// Кладет данные в стек
            /// </summary>
            /// <param name="obj">данные для внесения</param>
            public void Push(T obj)
            {
                data[position++] = obj;
                count++;
            }
            /// <summary>
            /// забирает данные из стека
            /// </summary>
            /// <returns>данные</returns>
            public T Pop()
            {
                --count;
                return data[--position];

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
}
