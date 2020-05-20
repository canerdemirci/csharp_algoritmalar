/*
** Disarium Numbers
** örn: 135 = 1^1 + 3^2 + 4^3 = 135
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    class Program_Disarium_Numbers
    {
        static void Main(string[] args)
        {
            int number;

            number = int.Parse(Console.ReadLine());
            
            Console.WriteLine("result: " + isDisarium(number));
        }

        static bool isDisarium(int num)
        {
            double total = 0;
            string numStr = num.ToString();

            for (int i=1; i<numStr.Length + 1; i++)
                total += Math.Pow(double.Parse($"{numStr[i-1]}"), Convert.ToDouble(i));

            if (total == num)
                return true;
            
            return false;
        }
    }
}
