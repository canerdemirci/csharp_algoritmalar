/*
** Verilen sayıdan küçük sayılar arasında
** asal bölen bir sayının karesi verilen sayıyı
** tam bölüyorsa o sayı lab number dır.
*/
using System;
using System.Collections;

class Program_Lab_Numbers
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];

            Console.WriteLine("Input 5 number: ");

            for (var i=0; i<5; i++)
                numbers[i] = int.Parse(Console.ReadLine());
            
            for (var i=0; i<5; i++)
                Console.WriteLine(
                    $"{numbers[i]} is " + 
                    (string)(isLabNumber(numbers[i]) == true ? "Lab number" : "not lab number")
                );
        }
        
        static bool isLabNumber(int n)
        {
            for (var i=2; i<n; i++)
                if (isPrime(i) && n % i == 0 && n % (i * i) == 0)
                    return true;
            
            return false;
        }

        static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            
            for (var i=n-1; i>=2; i--)
                if (n % i == 0)
                    return false;
            
            return true;
        }
    }
