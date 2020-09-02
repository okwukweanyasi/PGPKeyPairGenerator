using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PGPKeyPair
{
    public class PasswordPolicy
    {
        private static int minimumLength = 6;
        private static int upperCaseLength = 1;
        private static int lowerCaseLength = 1;
        private static int nonAlphaLength = 1;
        private static int numericLength = 1;

        public static bool IsValid(string Password)
        {
            if (Password.Length < minimumLength)
                return false;
            if (UpperCaseCount(Password) < upperCaseLength)
                return false;
            if (LowerCaseCount(Password) < lowerCaseLength)
                return false;
            if (NumericCount(Password) < 1)
                return false;
            if (NonAlphaCount(Password) < nonAlphaLength)
                return false;
            return true;
        }

        private static int UpperCaseCount(string Password)
        {
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }
    }
}
