/*
** Verilen sayıya kadar toplamları verilen sayıyı
** bulacak asal sayı ikililerini bulan program
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoloLearn
{
	class Program_Goldbachs_Conjecture
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a number which greater than 3");
            int num = int.Parse(Console.ReadLine());
            
            int half = num / 2;
            int onemuch = half;
            int oneless = half;

            if (isPrime(half) && isPrime(half + 1))
                if ((half + half + 1) == num)
                    Console.WriteLine($"{half} + {half + 1} = {half + half + 1}");

            if (isPrime(half) && isPrime(half - 1))
                if ((half + half - 1) == num)
                    Console.WriteLine($"{half} + {half - 1} = {half + half - 1}");

            if (isPrime(num - 2))
                if ((2 + (num - 2)) == num)
                    Console.WriteLine($"2 + {num - 2} = {2 + (num - 2)}");

            while (oneless >= 1)
            {
                if (isPrime(onemuch) && isPrime(oneless))
                {
                    if ((onemuch + oneless) == num)
                        Console.WriteLine($"{onemuch} + {oneless} = {onemuch + oneless}");
                }

                onemuch++;
                oneless--;
            }
        }

        static bool isPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;

            for (var i=2; i<n; i++)
                if (n % i == 0)
                    return false;
            
            return true;
        }
    }
}
