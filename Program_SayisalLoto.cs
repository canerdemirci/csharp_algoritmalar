using System;

namespace Caner
{
    class Program_SayisalLoto
    {
        static void Main(string[] args)
        {
            int[] alinanSayilar = new int[6];
            int[] rastgeleSayilar = new int[6];

            var index = 0;
            var secim = 0;

            Console.WriteLine("0: Kendin Yap, 1: Bilgisayara Bırak");
            secim = int.Parse(Console.ReadLine().Trim());

            if (secim == 1)
                randNum(alinanSayilar);
            else
                while (true)
                {
                    alinanSayilar[index] = int.Parse(Console.ReadLine().Trim());
                    
                    if (alinanSayilar[index] < 1 || alinanSayilar[index] > 49)
                        alinanSayilar[index] = 1;
                    
                    index++;

                    if (index == 6)
                        break;
                }

            randNum(rastgeleSayilar);

            Array.Sort(alinanSayilar);
            Array.Sort(rastgeleSayilar);

            for (var i=0; i<6; i++)
            {
                if (i == 0)
                    Console.WriteLine("Alınan sayılar: ");
                
                if (isContain(rastgeleSayilar, alinanSayilar[i]))
                    Console.BackgroundColor = ConsoleColor.Red;
                    
                Console.Write(alinanSayilar[i] + ", ");
                Console.ResetColor();
            }

            for (var i=0; i<6; i++)
            {
                if (i == 0)
                    Console.WriteLine("\n\nÜretilen sayılar: ");
                
                if (isContain(alinanSayilar, rastgeleSayilar[i]))
                    Console.BackgroundColor = ConsoleColor.Red;
                    
                Console.Write(rastgeleSayilar[i] + ", ");
                Console.ResetColor();
            }
        }

        static void randNum(int[] rastgeleSayilar)
        {
            var rand = new Random();
            int n = 0;

            for (var i=0; i<rastgeleSayilar.Length; i++)
            {
                while (true)
                {
                    n = rand.Next(1, 49);

                    if (!isContain(rastgeleSayilar, n))
                        break;
                }

                rastgeleSayilar[i] = n;
            }
        }

        static bool isContain(int[] arr, int n)
        {
            foreach (int i in arr)
                if (i == n)
                    return true;
            
            return false;
        }
    }
}
