/*
** Program 3 girdi alır
** Bir ufak sayı, bir büyük sayı ve bir işlem ifadesi
** Ufak sayıdan büyük sayıya kadar olan sayıların
** Verilen işlem ifadesiyle işlemleri toplamı bulunur.
** Örn: [2, 4, *2] => (2*2 + 3*2 + 4*2) = 18
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
	class Program_Summations_Calculator
	{
		static void Main(string[] args)
        {
            Console.WriteLine("Input minimum number: ");
            double min = double.Parse(Console.ReadLine());
            Console.WriteLine("Input maximum number: ");
            double max = double.Parse(Console.ReadLine());
            Console.WriteLine("Input operator: ");
            char opt = Console.ReadLine()[0];
            Console.WriteLine("Input operation number: ");
            double num = double.Parse(Console.ReadLine());

            try {
                Console.WriteLine(
                    Summation(min: min, max: max, opt: opt, num: num)
                );
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        static double Summation(double min, double max, char opt, double num)
        {
            double res = 0;

            if (min >= max)
                throw new Exception("Minumum value is must be less than maximum value");
            
            if (opt == '+' || opt == '-' || opt == '*' || opt == '/' || opt == '%')
                for (var i=min; i<=max; i++)
                    switch (opt)
                    {
                        case '+': res += i + num; break;
                        case '-': res += i - num; break;
                        case '*': res += i * num; break;
                        case '/': res += i / num; break;
                        case '%': res += i % num; break;
                    }
            else
                throw new Exception("Undefined operator");

            return res;
        }
	}
}
