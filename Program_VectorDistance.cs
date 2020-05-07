/*
** İki vektör arasındaki uzaklığı bulan program
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
		struct Vector2
        {
            public double x;
            public double y;

            public Vector2(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public static double Distance(Vector2 a, Vector2 b) =>
                Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.y - a.y), 2));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input first vector's x value");
            double ax = double.Parse(Console.ReadLine());
            Console.WriteLine("Input first vector's y value");
            double ay = double.Parse(Console.ReadLine());
            Console.WriteLine("Input second vector's x value");
            double bx = double.Parse(Console.ReadLine());
            Console.WriteLine("Input second vector's y value");
            double by = double.Parse(Console.ReadLine());

            Vector2 a = new Vector2(x: ax, y: ay);
            Vector2 b = new Vector2(x: bx, y: by);

            Console.WriteLine(
                "Distance: " + Vector2.Distance(a, b)
            );
        }
	}
}
