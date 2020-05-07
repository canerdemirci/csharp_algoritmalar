/*
** Program 10 luk sayı sisteminde verilen
** sayıyı istenilen sayı sistemine çevirir
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
	class Program_Base_Converter_10toBase
	{
		static void Main(string[] args)
		{
			int num, baseNum;
            string res = "";
            const string dig = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Console.WriteLine("Input an integer");
            num = int.Parse(Console.ReadLine());
            Console.WriteLine("Input a base");
            baseNum = int.Parse(Console.ReadLine());

            if (baseNum < 2 || baseNum > 36)
                return;
            
            while (num > 0)
            {
                res = dig[num % baseNum] + res;
                num /= baseNum;
            }

            Console.WriteLine($"Result: {res}");
		}
	}
}
