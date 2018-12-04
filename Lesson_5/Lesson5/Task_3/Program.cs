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

        static void Main(string[] args)
        {
            stroka = "[2/{5*(4+7)}]";
            Check(stroka);
        }

        /// <summary>
        /// проверка символов и распределение по стекам
        /// </summary>
        /// <param name="stroka"></param>
        private static void Check(string stroka)
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
            Console.WriteLine(CheckBracket(bracket));
        }


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

        private static bool OpenBracket(char v)
        {
            var temp = (v == '(') ? ')' : (v == '{') ? '}' : ']';
            if (!(checkBraket.count == 0) && temp.Equals(checkBraket.Pop())) return true;
            return false;
        }

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
            if (v.Equals('{')) return true;
            if (v.Equals('}')) return true;
            if (v.Equals('(')) return true;
            if (v.Equals(')')) return true;
            if (v.Equals('[')) return true;
            if (v.Equals(']')) return true;
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
    }
}
