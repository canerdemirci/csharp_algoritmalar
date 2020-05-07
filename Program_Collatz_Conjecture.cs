/*
** Program bir doğal sayı alır
** Sayı çift ise yarıya böler
** Tek ise 3 ile çarpar ve 1 ekler
** Bu işlemleri son 4, 2, 1 sonuçlarına 
** ulaşıncaya kadar devam ettirir.
** 1 den sonra işlemler devam etmez çünkü
** hep 4, 2, 1 diye gidcektir.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
    class Program_Collatz_Conjecture
    {
        static void Main(string[] args)
        {
            string inp = Console.ReadLine();
            int natNum = 0;
            int itNum = 0;
            
            inp = inp.Replace("-", "");
            
            if (int.TryParse(inp, out natNum)) {
                while (natNum > 1)
                {
                    if (natNum %2 == 0)
                        Console.WriteLine($"{natNum} / 2 = {natNum /= 2}");
                    else if (natNum %2 == 1)
                        Console.WriteLine($"{natNum} * 3 + 1 = {natNum = natNum * 3 + 1}");
                    itNum++;    
                 }
                 Console.WriteLine(itNum + " iteration");
            }
            else
                Console.WriteLine("Please, input a natural number");
        }
    }
}
