using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_Cows
{
    class Program
    {
        static Random random = new Random();
        static HashSet<int> hs = new HashSet<int>();
        static int[] userNumber = new int[4];
        static int[] randNumber = new int[4];
        static int countBull;
        static int countCow;
        static int count;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("\t\t\t\tБЫКИ И КОРОВЫ");
            Console.WriteLine("\n   Ваша задача - угадать 4-х значное число за ограниченное число ходов.\n В качестве подсказок выступают “Коровы” " +
                              "(цифра угадана, но её позиция - нет) \n и “Быки” (когда совпадает и цифра и её позиция). " +
                              "\n То есть если загадано число “1234”, а вы называете “6531”, то результатом будет 1 корова (цифра “1”) и 1 бык (цифра “3”).\n");

            RandomNumber();
            Func();

            while (countBull != 4)
            {
                count++;
                Func();
            }

            Console.Write("\n Загаданное число: ");
            foreach (var i in randNumber)
            {
                Console.Write(i);
            }
            Console.WriteLine("\n Кол-во попыток:{0}", count);
            Console.WriteLine("\n\n\t\t\t\tVICTORY!!!");
            Console.ReadKey();
        }

        /// <summary>
        /// Массив пользователя
        /// </summary>
        static void UserNumber()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write("  Введите число №{0}: ", i);
                userNumber[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        /// <summary>
        /// Рандомный массив
        /// </summary>
        static void RandomNumber()
        {
            while (hs.Count < 4)
            {
                hs.Add(random.Next(0, 9));
            }
            randNumber = hs.ToArray();
        }

        /// <summary>
        /// Проверка элементов массивов
        /// </summary>
        static void Check()
        {
            countBull = 0;
            countCow = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (userNumber[i] == randNumber[j])
                    {
                        if (i == j)
                        {
                            countBull++;
                        }
                        else
                        {
                            countCow++;
                        }
                    }
                }
            }
        }

        static void Func()
        {
            try
            {
                UserNumber();
            }
            catch
            {
                Console.WriteLine("\n\t\tПоле содержит только цифры!\n");
                return;
            }
            Check();
            Console.WriteLine();
            Console.WriteLine("\tБыки - {0}", countBull);
            Console.WriteLine("\tКоровы - {0}", countCow);
            Console.WriteLine();
        }
    }
}
