/*
** Verilen metinden boşlukları silen program
*/

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
            string str = Console.ReadLine();
            string newstr = "";
            
            for (var i=0; i<str.Length; i++)
                if (str[i] != ' ')
                    newstr += str[i];
            
            Console.WriteLine(newstr);    
        }
    }
}
