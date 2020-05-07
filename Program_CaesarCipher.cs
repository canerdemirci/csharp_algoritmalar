/*
** Caesar Cipher
** -------------------------------------------
** Sezar Şifrelemesi
** Şifrelenecek metin karakterleri alfabedeki konumlarına göre,
** verilen anahtar tam sayı değeri kadar ileri kaydırılır.
** Şifre çözülürken de geri kaydırılır.
**
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace csharpdenemeler
{
    class Program_CaesarCipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string: ");
            string str = Console.ReadLine();
            Console.WriteLine("Input key: ");
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine("CaesarCipher string: ");
            str = CaesarCipher.Do(str, key, true);
            Console.WriteLine(str);
            Console.WriteLine("Decode string: ");
            str = CaesarCipher.Do(str, key, false);
            Console.WriteLine(str);
        }
    }

    public static class CaesarCipher
    {
        static readonly char[] TREN_ALPHABET = 
        {
            'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü',
            'v', 'y', 'z', 'w', 'x', 'q', '0', '1', '2', '3', '4', '5', '6',
            '7', '8', '9'
        };

        /*
        ** Hem kodlar hem kod açar
        */
        public static string Do(string str, int key=1, bool encode = true)
        {
            // Anahtar alfabe dizisinin dışındaysa 1'e eşitle
            if (key < 1 || key > TREN_ALPHABET.Length - 1)
                key = 1;
            
            // Girilen metni char dizisine dönüştür
            char[] chars = str.Trim().ToLower().ToCharArray();
            str = "";

            for (var i=0; i<chars.Length; i++)
            {
                // Her harfin alfabe tablosunda karşılık gelen indeksini al
                int cindex = charIndex(chars[i]);

                // Bir karakter bizim tabloda varsa anahtar ile değiştir
                // yoksa karakteri olduğu gibi str içine at
                if (cindex != -1)
                {
                    // Kodlanacaksa anahtarı ekle kodlanmayacaksa çıkar
                    if (encode)
                        cindex += key;
                    else
                        cindex -= key;

                    // indeks alfabe tablosunu aştıysa başa döndür
                    if (cindex > TREN_ALPHABET.Length - 1)
                        cindex = cindex - TREN_ALPHABET.Length;
                    // indeks 0'ın altındaysa tablo sonundan döndür
                    if (cindex < 0)
                        cindex = TREN_ALPHABET.Length + cindex;

                    // Karakterleri değiştir
                    chars[i] = TREN_ALPHABET[cindex];
                }

                // Şifrelenmiş ya da çözülmüş string
                str += chars[i];
            }
            
            return str;
        }

        /*
        ** Bir karakterin bizim karakter tablosundaki indeksini döndürür
        ** Mevcut değilse -1 değeri döndürür.
        */
        static int charIndex(char c)
        {
            for (var i=0; i<TREN_ALPHABET.Length; i++)
                if (TREN_ALPHABET[i] == c)
                    return i;
            
            return -1;
        }
    }
}
