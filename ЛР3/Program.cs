using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР4
{
    internal class Program
    {
        delegate int Operation(int num1, int num2);
        static void Main(string[] args)
        {
            Operation multiplication = (num1, num2) => num1 * num2;
            Operation summation = (num1, num2) => num1 + num2;
            Table(10, 10, multiplication, "Таблица умножения");
            Table(10, 10, summation, "Таблица сумирования");
            Console.ReadKey();
        }

        static void Table(int x, int y, Operation operation, string Name_Table)
        {
            Console.WriteLine();
            Console.WriteLine(Name_Table);
            for (int i = 1; i <= x; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\t{i}");
            }
            Console.WriteLine();
            for (int i = 1; i <= y; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i);
                for (int j = 1; j <= x; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t{operation(i, j)}");
                }
                Console.WriteLine();
            }
        }
    }
}
