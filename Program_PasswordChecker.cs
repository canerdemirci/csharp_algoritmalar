/*
** Girilen parolayı belli koşullara göre denetleyen program
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoloLearn
{
    class PasswordChecker
    {
        public static bool Check(string psw)
        {
            int numbers = 0;
            int specials = 0;
            string errors = "";
            
            psw = psw.Replace(" ", "");
            
            if (psw.Length < 5 || psw.Length > 10)
                errors += "Password's length must between 5 and 10&";
                 
            for (var i=0; i<psw.Length; i++)
            {
                if (psw[i] > 47 && psw[i] < 58)
                    numbers++;  
                    
                if ((psw[i] > 32 && psw[i] < 48) || (psw[i] > 57 && psw[i] < 65) || (psw[i] > 90 && psw[i] < 97) || psw[i] == 126)
                    specials++;
            } 
                         
            if (numbers == 0)
                errors += "There must be a number at least&";
            
            if (specials == 0)
                errors += "There must be a special character at least&";
                
            if (errors != "") {
                errors = string.Join("\n", errors.Split('&'));
                throw new Exception(errors);
            }  
                          
            return true;
         }
    }
    
    class Program_PasswordChecker
    {
        static void Main(string[] args)
        {
            string psw = Console.ReadLine();
            
            try {
                if (PasswordChecker.Check(psw))
                    Console.WriteLine("Okay");
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
