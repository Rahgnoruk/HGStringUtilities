using System.Linq;
using System.Text.RegularExpressions;

namespace Util.String
{
    public static class StringVerification
    {
        public static bool HasMinimumLength(string str, int minLength)
        {
            return str.Length >= minLength;
        }

        public static bool HasUpperCaseLetter(string str)
        {
            return str.Any(c => char.IsUpper(c));
        }

        public static bool HasLowerCaseLetter(string str)
        {
            return str.Any(c => char.IsLower(c));
        }

        public static bool HasDigit(string str)
        {
            return str.Any(c => char.IsDigit(c));
        }

        public static bool HasSpecialCharacter(string str)
        {
            return str.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }

        public static bool HasEmailFormat(string str)
        {
            Regex regex = new Regex(@".+@[a-zA-Z0-9]+\.([a-zA-Z]{2,3}|[0-9]{1,3})");
            Match result = regex.Match(str);

            return result.Success;
        }

        public static bool IsNullOrEmpty(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNullsOrEmpties(params string[] strs)
        {
            foreach (string str in strs)
            {
                if (IsNullOrEmpty(str)) return true;
            }

            return false;
        }

        public static bool HasLinkFormat(string str)
        {
            Regex regex = new Regex(@".+@[a-zA-Z0-9]+\.([a-zA-Z]{2,3}|[0-9]{1,3})");
            Match result = regex.Match(str);

            return result.Success;
        }

        public static bool HasGivenLinkFormat(string str, string givenLink)
        {
            Regex regex = new Regex(@".*" + givenLink + @"(\/.*)?");
            Match result = regex.Match(str);

            return result.Success;
        }
    }
}