/*
** Parola kontrolü yapan program
** En az 2 rakam, 2 özel karakter olmalı
** boşluk olmamalı ve en az 1 harf olmalı
*/

using System;

namespace Alghorithms_Practices
{
    class Program_Password_Validator
    {
        static readonly string SPCHARS = "!@#$%&*";
        static readonly string NUMBERS = "0123456789";

        static void Main(string[] args)
        {
            string psw = Console.ReadLine().Replace(" ", "");

            if (!CheckPassword(psw))
                Console.WriteLine("Weak");
            else
                Console.WriteLine("Strong");
        }

        static bool CheckPassword(string psw)
        {
            int numCount = 0;
            int spcharCount = 0;

            if (psw.Length < 7)
                return false;
            
            foreach (char c in psw)
            {
                if (isCharContains(NUMBERS, c))
                    numCount++;

                if (isCharContains(SPCHARS, c))
                    spcharCount++;
            }

            if (numCount < 2 || spcharCount < 2)
                return false;

            if (psw.Length == (numCount + spcharCount))
                return false;

            return true;
        }

        static bool isCharContains(string arr, char c)
        {
            foreach (char i in arr)
                if (i == c)
                    return true;
            
            return false;
        }
    }
}
