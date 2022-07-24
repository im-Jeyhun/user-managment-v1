using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using user_management_v1.DataBase.Repository;

namespace user_management_v1.ApplicationLogic.Validation
{
    public class UserValidation
    {
        public static bool IsLengthCorrect(string text, int startLengt, int endLength)
        {
            return text.Length >= startLengt && text.Length <= endLength;
        }

        public static bool IsNameValid(string name)
        {
            string patterms = "^[A-Z][a-zA-z]{3,30}$";
            Regex regex = new Regex(patterms);
            if (regex.IsMatch(name))
            {
                return true;
            }
            Console.WriteLine("The name you entered is incorrect, make sure the name contains only letters, the first letter is capitalized, and the length is greater than 3 and less than 30.");
            return false;
        }

        public static bool IsLastNameValid(string lastName)
        {
            string patterms = "^[A-Z][a-zA-z]{3,30}$";
            Regex regex = new Regex(patterms);
            if (regex.IsMatch(lastName))
            {
                return true;
            }
            Console.WriteLine("The surnam you entered is incorrect, make sure the name contains only letters, the first letter is capitalized, and the length is greater than 3 and less than 30.");

            return false;
        }

        public static bool IsValidEmail(string email)
        {
            string patterns = @"^([a-zA-Z0-9]{10,30})(@code\.edu\.az)$";
            Regex regexemail = new Regex(patterns);
            if (regexemail.IsMatch(email))
            {
                return true;
            }
            Console.WriteLine("Email must be like that exampleemail@code.edu.az");
            return false;
        }

        public static bool IsUserExistsByEmail(string email)
        {
            if (!UserRepository.IsEmailExists(email))
            {
                return true;
            }
            Console.WriteLine("Email already exists");
            return false;
        }

        public static bool IsPasswordValid(string password)
        {
            string patterns = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            Regex regexpassword = new Regex(patterns);
            if (regexpassword.IsMatch(password))
            {
                return true;
            }
            Console.WriteLine("In password must be one Upper case , one lower case , and pass must be upper than 8");
            return false;
        }

        public static bool IsPasswordSame(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            Console.WriteLine("Passwords not same .....");
            return false;
        }
    }
}
