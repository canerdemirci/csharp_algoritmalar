/*
** Büyük Sayıları 10 üzeri şeklinde yazan program
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    class Program_Scientific_Notation
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Console.WriteLine(SfNotation(input));

            Console.WriteLine("\nOther Exampless");
            Console.WriteLine("===============================");
            Console.WriteLine(SfNotation("0,0000000000667"));
            Console.WriteLine(SfNotation("9000000000"));
        }

        static string SfNotation(string input)
        {
            string output = "";
            int zero = 0;
            bool zeroStart = false;
            string digit = "";
            int i = 0;

            if (input[0] == '0') {
                i = 1;
                zeroStart = true;
            }
            
            for (; i<input.Length; i++)
                if (input[i] == '0')
                    zero++;
                else
                    if (input[i] != '0' && input[i] != ',')
                        digit += input[i];

            input = input.Replace("0", "");
            digit = digit[0] + "," + digit.Substring(1, digit.Length - 1);

            if (!zeroStart)
                output = $"{input}*10^{zero}";
            else
                output = $"{digit}*10^-{zero + 1}";
            
            return output;
        }
    }
}
