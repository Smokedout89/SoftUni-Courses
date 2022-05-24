using System;

namespace P04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            const int minLength = 6;
            const int maxLength = 10;

            bool isPasswordValid = PasswordValidator(password, minLength, maxLength);

            if (isPasswordValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool PasswordValidator(string password, int minLength, int maxLength)
        {
            bool isPasswordValid = true;

            if (!ValidateLength(password, minLength, maxLength))
            {
                Console.WriteLine($"Password must be between {minLength} and {maxLength} characters");
                isPasswordValid = false;
            } 
            if (!ValidateOnlyLettersAndDigits(password))
            {
                Console.WriteLine($"Password must consist only of letters and digits");
                isPasswordValid = false;
            }
            if (!ValidateDigitsCount(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isPasswordValid = false;
            }

            return isPasswordValid;
        }

        static bool ValidateLength(string password, int minLength, int maxLength)
        {

            if (password.Length >= minLength && password.Length <= maxLength)
            {
                return true;
            }

            return false;
        }

        static bool ValidateOnlyLettersAndDigits(string password)
        {
            foreach (char ch in password)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ValidateDigitsCount(string password)
        {
            int digitsCount = 0;

            foreach (char ch in password)
            {
                if (char.IsDigit(ch))
                {
                    digitsCount++;
                }
            }

            if (digitsCount >= 2)
            {
                return true;
            }

            return false;
        }
    }
}
