/*
** Aldığı metni harflerini alfabedeki sırasının tam zıttıyla
** değiştirerek şifreler örn: abc -> zyx
*/

using System;

namespace Caner
{
    class Program_SecretMessage
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World => " + SecretMessage.Do("Hello World"));
            Console.WriteLine("svool dliow => " + SecretMessage.Do("svool dliow"));
            string inputStr = Console.ReadLine();
            inputStr = SecretMessage.Do(inputStr);
            Console.WriteLine(inputStr);
        }
    }

    class SecretMessage
    {
        static readonly string R_ALPHABET = "zyxwvutsrqponmlkjihgfedcba";
        static readonly string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public static string Do(string str)
        {
            str = str.ToLower();
            string encoded = "";

            for (var i=0; i<str.Length; i++)
            {
                int cindex = findCharIndex(str[i]);

                if (cindex != -1)
                    encoded += R_ALPHABET[cindex];
                else
                    encoded += str[i];
            }

            return encoded;
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
