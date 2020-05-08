/*
** Vigenere Cipher
** =================================================
** Aldığı metni, aldığı anahtar ile şu işlemlerden geçirdikten sonra
** şifrelemiş olur:
** metnin harf değeri ile anahtarın harf değerini toplar ve sonuç değeri
** alfabedeki başka bir harfe işaret eder. Aldığı metnin harfini bununla
** değiştirererk şifreler.
*/

using System;

namespace Scrabble
{
    class Program_Vigenere_Cipher
    {
        static void Main(string[] args)
        {
            string str, key;

            Console.WriteLine("Input a string: ");
            str = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Input a key string: ");
            key = Console.ReadLine().Trim().ToLower();

            if (key.Length > str.Length)
                key = key.Substring(0, str.Length);
            
            foreach (var k in key)
                if (VigenereCipher.findCharIndex(k) == -1)
                {
                    Console.WriteLine("Input a correct key string. Special characters are not allowed!");
                    return;
                }

            Console.WriteLine("Encoded string is: ");
            string encstr = VigenereCipher.Do(str, key);
            Console.WriteLine(encstr);
            Console.WriteLine("Decoded string is: ");
            Console.WriteLine(VigenereCipher.Do(encstr, key, false));

            Console.WriteLine("\nOther Examples");
            Console.WriteLine("====================================");
            Console.WriteLine("input: so_lo _learn& key: web");
            encstr = VigenereCipher.Do("so_lo _learn&", "web");
            Console.WriteLine(encstr);
            Console.WriteLine("input: " + encstr + " key: web");
            Console.WriteLine(VigenereCipher.Do(encstr, "web", false));
        }
    }

    class VigenereCipher
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static string Do(string str, string key, bool encode = true)
        {
            string encodedStr = "", decStr = "";
            int k = 0;

            for (var i=0; i<str.Length; i++)
            {
                int a = findCharIndex(str[i]);
                int b = findCharIndex(key[k]);

                int index = encode == true ? a + b : a - b;

                if (encode)
                    index = index > alphabet.Length - 1 ? index - alphabet.Length : index;
                else
                    index = index < 0 ? index + alphabet.Length : index;

                if (encode)
                    encodedStr += a == -1 ? str[i] : alphabet[index];
                else
                    decStr += a == -1 ? str[i] : alphabet[index];
                
                if (a != -1)
                    k++;

                if (k == key.Length)
                    k = 0;
            }
            
            if (encode)
                return encodedStr;
            else
                return decStr;
        }

        public static int findCharIndex(char c)
        {
            for (var i=0; i<alphabet.Length; i++)
                if (alphabet[i] == c)
                    return i;
            
            return -1;
        }
    }
}
