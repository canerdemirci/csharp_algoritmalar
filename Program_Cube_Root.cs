/*
** Verilen sayının küp kökünü bulur (0.0001 hassasiyetle)
** Örn: 2*2*2 = 8 | 729 => 9
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoloLearn
{
	class Program_Cube_Root
	{
		static void Main(string[] args)
		{
		    double nm = double.Parse(Console.ReadLine());
            Console.WriteLine($"root: {FindCubeRoot(nm)}");
		}
		
		static double FindCubeRoot(double num)
        {
            double start = 0, end = num;
            double precision = 0.0001;

            while (true)
            {
                double mid = (start + end) / 2;
                double err = (num > (mid*mid*mid)) ? (num - (mid*mid*mid)) : ((mid*mid*mid) - num);

                if (err <= precision)
                    return mid;
                
                if ((mid*mid*mid) > num)
                    end = mid;
                else
                    start = mid;
            }
        }
	}
}
