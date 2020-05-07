/*
** Program 1 bilinmeyenli denklemleri çözer
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
	public static class LinearEquation
    {
	/*
	** Bu fonksiyon bilinmeyenin karakterini (adını) ve değerini döndürür
	*/
        public static (char, double) Do(string expression)
        {
            // Bilinmeyenin değeri
            double xnum = 0.0;
            // Bilinmeyenin ismi (örn: x)
            char x = '\0';
            // Bilinmeyenin string ifade içindeki indeksi
            int xindex = 0;
            // Bilinmeyenin katsayısı
            double xfactor = 0.0;
            // Eşittir işaretinin indeksi
            int equalindex = 0;
            // Bilinmeyen ifadenin başlangıç indeksi (operatörüyle örn: -2x)
            int xstart = 0;
            // Bilinmeyen dışındaki iki sayı (operatörleriyle örn: -10, +5)
            double number1 = 0.0, number2 = 0.0;
            // İşlem (çarpma, bölme, veya toplama çıkarma)
            char operation = '\0';

            // Find equals sign index
            equalindex = expression.IndexOf('=');
            
            // Find x and its index
            for (var i=0; i<expression.Length; i++)
                if (isX(expression[i]))
                {
                    x = expression[i];
                    xindex = i;
                }

            // Find x factor
            if (xindex == 0 || (xindex > equalindex && xindex - equalindex == 1)) {
                xfactor = 1;
                xstart = xindex;
            }
            else
                for (var i=xindex-1; i>=0; i--)
                {
                    if (expression[i] == '=' || isMulDiv(expression[i])) {
                        xstart = i + 1;
                        break;
                    }
                    
                    string xn = expression.Substring(i, xindex - i);
                    xfactor = double.Parse(xn == "-" ? "-1" : xn);

                    if (isMinSum(expression[i])) {
                        xstart = i;
                        break;
                    }
                }
            
            // operation side
            if (xindex > equalindex)
            {
                // x in left
                expression = expression.Remove(xstart, xindex-xstart+1);
                string exp1 = expression.Split('=')[0];
                string exp2 = expression.Split('=')[1]; 

                if (exp2.Contains("*"))
                    operation = '*';
                else if (exp2.Contains("/"))
                    operation = '/';

                exp2 = exp2.Replace("*", "");
                exp2 = exp2.Replace("/", "");
                number1 = double.Parse(exp2);
                number2 = double.Parse(exp1);
            }   
            else
            {
                // x in right
                expression = expression.Remove(xstart, xindex-xstart+1);
                string exp1 = expression.Split('=')[0];
                string exp2 = expression.Split('=')[1];
                if (exp1.Contains("*"))
                    operation = '*';
                else if (exp1.Contains("/"))
                    operation = '/';
    
                exp1 = exp1.Replace("*", "");
                exp1 = exp1.Replace("/", "");

                
                number1 = double.Parse(exp1);
                number2 = double.Parse(exp2);
            }

            if (operation == '\0')
                xnum = (-number1 + number2) / xfactor;
            else
                if (operation == '*')
                    xnum = (number2 / number1) / xfactor;
                else if (operation == '/')
                    xnum = (number2 * number1) / xfactor;

            return (x, xnum);
        }

        static bool isX(char x)
        {
            int i;
            if (!int.TryParse(x.ToString(), out i) && !isMinSum(x) && !isMulDiv(x) && x != '=')
                return true;
            
            return false;
        }

        // + or -
        static bool isMinSum(char o) => o == '+' || o == '-' ? true : false;

        // * or /
        static bool isMulDiv(char o) => o == '*' || o == '/' ? true : false;
    }
    
    class Program_LinearEquation
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            var result = LinearEquation.Do(expression);        

            Console.WriteLine($"Result is: {result.Item1} = {result.Item2}\n");

            Console.WriteLine("Other examples: \n");
            Console.WriteLine("===========================");
            Console.WriteLine("2x-1=5 => " + LinearEquation.Do("2x-1=5"));
            Console.WriteLine("5=2x-1 => " + LinearEquation.Do("5=2x-1"));
            Console.WriteLine("10=3a+1 => " + LinearEquation.Do("10=3a+1"));
            Console.WriteLine("10=2a-30 => " + LinearEquation.Do("10=2a-30"));
            Console.WriteLine("10x-20=30 => " + LinearEquation.Do("10x-20=30"));
            Console.WriteLine("50=20c-10 => " + LinearEquation.Do("50=20c-10"));
            Console.WriteLine("3y-20=-2 => " + LinearEquation.Do("3y-20=-2"));
            Console.WriteLine("5a-5=0 => " + LinearEquation.Do("5a-5=0"));
            Console.WriteLine("0=5a-5 => " + LinearEquation.Do("0=5a-5"));
            Console.WriteLine("-2b+5=7 => " + LinearEquation.Do("-2b+5=7"));
            Console.WriteLine("7=-2b+5 => " + LinearEquation.Do("7=-2b+5"));
            Console.WriteLine("x-5=0 => " + LinearEquation.Do("x-5=0"));
            Console.WriteLine("0=x-5 => " + LinearEquation.Do("0=x-5"));
            Console.WriteLine("-3+2a=9 => " + LinearEquation.Do("-3+2a=9"));
            Console.WriteLine("9=-3+2a => " + LinearEquation.Do("9=-3+2a"));
            Console.WriteLine("-30=-24-2a => " + LinearEquation.Do("-30=-24-2a"));
            Console.WriteLine("a+5=12 => " + LinearEquation.Do("a+5=12"));
            Console.WriteLine("0=5-x => " + LinearEquation.Do("0=5-x"));
            Console.WriteLine("5=0-x => " + LinearEquation.Do("5=0-x"));
            Console.WriteLine("12z*2=72 => " + LinearEquation.Do("12z*2=72"));
            Console.WriteLine("72=2*12z => " + LinearEquation.Do("72=2*12z"));
            Console.WriteLine("4b/2=16 => " + LinearEquation.Do("4b/2=16"));
            Console.WriteLine("16=4b/2 => " + LinearEquation.Do("16=4b/2"));
            Console.WriteLine("125x+500=750 => " + LinearEquation.Do("125x+500=750"));
            Console.WriteLine("-125x-500=-750 => " + LinearEquation.Do("-125x-500=-750"));
        }
    }
}
