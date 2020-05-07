/*
** Verilen sayıyı 10 luk sayı sistemindeki karşılığına çevirir
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
	class Program_Base_Converter_baseTo10
	{
		static void Main(string[] args)
        {
            string number;
            int baseNum;
            char[] figures;
            int counter = -1;
            int total = 0;

            Console.WriteLine("Input an integer");
            number = Console.ReadLine();
            Console.WriteLine("Input a base");
            baseNum = int.Parse(Console.ReadLine());
            figures = number.ToCharArray();

            for (var i=figures.Length - 1; i>=0; i--)
            {
                counter++;
                total += int.Parse(figures[i].ToString()) * Pow(baseNum, counter);
            }

            Console.WriteLine($"Result: {total}");
        }

        static int Pow(int n, int power)
        {
            int res = 1;

            for (var i=0; i<power; i++)
                res = n * res;
            
            return res;
        }
	}
}
