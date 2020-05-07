/*
** Gapful numbers
** Gapful sayılar en az 3 basamaklıdır ve
** 1. ve 3. rakamlarının oluşturduğu sayıya
** tam bölünebilirler.
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
            int num = 0;

            if (int.TryParse(Console.ReadLine(), out num))
                Console.Write(Gapful(num) ? "Gapful" : "Not Gapful");
        }

        static bool Gapful(int num)
        {
            string numStr = Convert.ToString(num);

            if (numStr.Length < 3)
                return false;
            
            char first = numStr[0];
            char last = numStr[numStr.Length - 1];
            int fl = int.Parse($"{first}{last}");

            if (num % fl != 0)
                return false;

            return true;
        }
	}
}
