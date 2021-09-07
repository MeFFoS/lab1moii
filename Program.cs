using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOII_lab1
{
    class Program
    {
        static List<string> Names;
        static List<string[]> Matrix;
        static List<int> Values;
        static string GetElement(int element)
        {
            return Names[element];
        }
        static void WriteTree(int size, int row = 0, int countOfTabs = 0)
        {
            Console.Write("{0}", GetElement(row));
            if (Values[row] != 0)
                Console.Write(" = {0}", Values[row].ToString());
            Console.Write("\n");
            for (int i = 0; i < size; i++)
            {
                if (i != row)
                    switch (Matrix[row][i])
                    {
                        case "1":
                            for (int k = 0; k <= countOfTabs; k++)
                                Console.Write(" ¦ ");
                            Console.Write(" ");
                            WriteTree(size, i, countOfTabs + 1);
                            break;
                        case "2":
                            for (int k = 0; k <= countOfTabs; k++)
                                Console.Write(" ¦ ");
                            Console.Write("*");
                            WriteTree(size, i, countOfTabs + 1);
                            break;
                        default:
                            break;
                    }
            }
        }
        private static void ReadInput()
        {
            var input = File.ReadAllLines("input.txt");
            foreach (var item in input)
            {
                var parts = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Matrix.Add(parts[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                Names.Add(parts[1].Replace('_', ' '));
                try
                {
                    Values.Add(int.Parse(parts[2]));
                }
                catch
                {
                    Values.Add(0);
                }
            }
        }
        static void Main(string[] args)
        {
            Names = new List<string>();
            Matrix = new List<string[]>();
            Values = new List<int>();
            ReadInput();
            Values[0] = Values[6] * (Values[5] - Values[2]);
            WriteTree(Matrix.Count);
            Console.ReadKey();
        }
    }
}
