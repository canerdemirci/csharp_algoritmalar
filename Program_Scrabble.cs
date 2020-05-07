/*
** Program kullanıcıdan 5 kelime alır
** Harf tablosunda her harfin bir puanı vardır
** Buna göre kelimeler puanlanır
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoloLearn
{
	class Program_Scrabble
    {
        static void Main(string[] args)
        {
            char[] chars = {
                'e', 'a', 'i', 'o', 'n', 'r', 't', 'l', 's', 'u',
                'd', 'g', 'b', 'c', 'm', 'p', 'f', 'h', 'v', 'w',
                'y', 'k', 'j', 'x', 'q', 'z'
            };

            string[] input = new string[5];
            int[] points = new int[5];
            int wordPoint = 0;

            for (var i=0; i<5; i++)
                input[i] = Console.ReadLine().Trim().ToLower();
            
            for (var i=0; i<input.Length; i++)
            {
                for (var j=0; j<input[i].Length; j++)
                    wordPoint += findPoint(chars, input[i][j]);

                points[i] = wordPoint;

                Console.WriteLine(input[i] + " : " + points[i]);
                
                wordPoint = 0;
            }
        }

        static int findPoint(char[] chardb, char c)
        {
            for (var i=0; i<chardb.Length; i++)
                if (chardb[i] == c)
                {
                        if (i < 10) return 1;
                        if (i > 9 && i < 12)  return 2;
                        if (i > 11 && i < 16) return 3;
                        if (i > 15 && i < 21) return 4;
                        if (i == 21) return 5;
                        if (i > 21 && i < 24) return 8;
                        if (i > 23 && i < 26) return 10;
                }
                
            return 0;
        }
    }
}
