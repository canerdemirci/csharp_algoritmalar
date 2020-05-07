using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
    class Program
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
