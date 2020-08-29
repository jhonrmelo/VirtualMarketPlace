using System;

namespace Helpers
{
    public static class PasswordHelper
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";

        public static string GeneratePassword(int passwordSize)
        {
            char[] password = new char[passwordSize];
            Random _random = new Random();
            int counter;

            string charSet = $"{LOWER_CASE}{UPPER_CASE}{NUMBERS}{SPECIALS}";

            for (counter = 0; counter < passwordSize; counter++)
            {
                password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, password);
        }
    }
}
