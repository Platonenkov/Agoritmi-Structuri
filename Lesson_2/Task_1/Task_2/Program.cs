using System;

namespace Task_2
{

        //    2. Реализовать функцию возведения числа a в степень b:
        //a.Без рекурсии.
        //b.Рекурсивно.
        //c. *Рекурсивно, используя свойство чётности степени.
    class Program
    {
        static int a;
        static int stepen;
        static bool flag;
        static int variant;
        static int resalt = 0;

        static void Main(string[] args)
        {

            while (true)
            {
                    InfoUser();
                    InitVariant();
                    Init();
                    Select(variant);
            }
        }

        /// <summary>
        /// Вывод информации о действии программы
        /// </summary>
        static void InfoUser()
        {
            Console.WriteLine("возведения числа a в степень b");
            Console.WriteLine("1. Без рекурсии.");
            Console.WriteLine("2. Рекурсивно");
            Console.WriteLine("3. *Рекурсивно, используя свойство чётности степени");
            Console.WriteLine();
        }

        /// <summary>
        /// Выбор варинта работы
        /// </summary>
        static void InitVariant()
        {
            flag = false;
            variant = 0;
            while (!(flag && (variant > 0 && variant < 4)))
            {
                Console.Write("Выберите вариант: ");
                flag = int.TryParse(Console.ReadLine(), out variant);
                if (!flag || (variant < 1 || variant > 3))
                {
                    flag = false;
                    Console.WriteLine("Выбор не понятен, выберите 1, 2 или 3");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Инициализация переменных числа и степени
        /// </summary>
        static void Init()
        {
            Console.WriteLine("Введите возводимое число");
            while (!int.TryParse(Console.ReadLine(),out a))
            Console.WriteLine("Введите ЧИСЛО 'A'");

            Console.WriteLine("Введите степень");
            while (!int.TryParse(Console.ReadLine(), out stepen)||!(stepen>=0))
            Console.WriteLine("Введите ЧИСЛО 'B' больше или равное 0");
        }

        /// <summary>
        /// Выполнение программы в соответствии выбору пользователя
        /// </summary>
        /// <param name="var">Вариан выполнения программы 1, 2, 3.</param>
        static void Select(int var)
        {
            switch (var)
            {
                case 1: Variant_1();
                    break;
                case 2: Variant_2();
                    break;
                case 3: Variant_3();
                    break;
                default: Console.WriteLine("Выбор неясен, начните заново");
                    break;
            }
        }
        /// <summary>
        /// решение без рекурсии
        /// </summary>
        static void Variant_1()
        {
            if (stepen == 0)
            {
                Console.WriteLine("\nЛюбое число кроме 0 в степени 0 = 1.\n");
                return;
            }
            if (a == 0)
            {
                Console.WriteLine("\n0 в любой степени = 0.\n");
                return;
            }
          
            resalt = a;
            for (int i = 0; i < stepen-1; i++)
                resalt = resalt * a;
            Console.WriteLine($"\nЧисло 'A' = {a}, в степени 'b' = {stepen}, равно {resalt}.\n");
        }
        /// <summary>
        /// Решение рекурсивно
        /// </summary>
        static void Variant_2()
        {
            var temp = stepen;
            if (a < 0 && stepen % 2 == 1)
                resalt = RecurseVariant(a);
            else if (a < 0 && stepen % 2 == 0)
                resalt = RecurseVariant(a);
            else if (stepen == 1) resalt = a;
            else if (stepen == 0) resalt = 1;
            else resalt = RecurseVariant(a);

            Console.WriteLine($"\nЧисло 'A' = {a}, в степени 'b' = {temp}, равно {resalt}.\n");
        }

        static int RecurseVariant(int _a)
        {
            stepen--;
            if (stepen == 0) return _a;
            return RecurseVariant(_a * a);
        }
        /// <summary>
        /// рекрсивно используя четность числа
        /// </summary>
        static void Variant_3()
        {
            Console.WriteLine("\nЗадача с четностью не понята...\n " +
                "Четность степени по умолчанию решается в двух первых вариантах");
        }
    }

}
