/*
** Aldığı metni alfabetik harf sırasına sokar
** Özel karakterler en önde, sonra rakamlar, sonra harfler olur
*/
using System;

namespace Caner
{
    class Program_String_Sorting
    {
        static readonly string ALPHABET = "0123456789abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine().ToLower();
            inputStr = SortString(inputStr);
            Console.WriteLine(inputStr);
        }

        static string SortString(string str)
        {
            int[] indexes;
            string specialChars = "";
            string resultStr = "";
            string newStr = "";

            foreach (char s in str)
                if (findCharIndex(s) == -1)
                    specialChars += s;
                else
                    newStr += s;
                
            indexes = new int[newStr.Length];

            for (var i=0; i<newStr.Length; i++)
                indexes[i] = findCharIndex(newStr[i]);

            Array.Sort(indexes);

            resultStr += specialChars;

            for (var i=0; i<indexes.Length; i++)
                resultStr += ALPHABET[indexes[i]];

            return resultStr;
        }

        static int findCharIndex(char c)
        {
            for (var i=0; i<ALPHABET.Length; i++)
                if (c == ALPHABET[i])
                    return i;

            return -1;
        }
    }
}
