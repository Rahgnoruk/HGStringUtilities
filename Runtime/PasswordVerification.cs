namespace Util.String
{
    public enum PasswordStrength
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 6
    }

    public enum PasswordOption
    {
        RequiredLength,
        RequiredUniqueChars,
        //RequireNonAlphanumeric,
        RequireLowercase,
        RequireUppercase,
        RequireDigit
    }

    public class PasswordVerification
    {
        public static (string, PasswordStrength) CheckPasswordStrength(string password, int weakLength, int strongLenght)
        {
            int score = 0;

            // Check password to check its strength score
            if (StringVerification.IsNullOrEmpty(password)) return ("Password not inputed", PasswordStrength.Blank);
            if (StringVerification.HasMinimumLength(password, weakLength)) score++;
            if (StringVerification.HasMinimumLength(password, strongLenght)) score++;
            if (StringVerification.HasLowerCaseLetter(password)) score++;
            if (StringVerification.HasUpperCaseLetter(password)) score++;
            if (StringVerification.HasDigit(password)) score++;
            if (StringVerification.HasSpecialCharacter(password)) score++;

            switch (score)
            {
                case 1:
                    return ("Very weak", PasswordStrength.VeryWeak);
                case 2:
                    return ("Weak", PasswordStrength.Weak);
                case 3:
                    return ("Medium", PasswordStrength.Medium);
                case 4:
                    return ("Strong", PasswordStrength.Strong);
                case 5:
                    return ("Strong", PasswordStrength.Strong);
                case 6:
                    return ("Very strong", PasswordStrength.VeryStrong);
                default:
                    return ("Password not inputed", PasswordStrength.Blank);
            }
        }

        public static bool IsValidPassword(string password, params PasswordOption[] options)
        {
            // Check each option to verify if the password meets the requirements
            foreach(PasswordOption option in options)
            {
                switch(option)
                {
                    case PasswordOption.RequiredLength:
                        if (!StringVerification.HasMinimumLength(password, 3)) return false;
                        break;
                    case PasswordOption.RequiredUniqueChars:
                        if (!StringVerification.HasSpecialCharacter(password)) return false;
                        break;
                    case PasswordOption.RequireLowercase:
                        if (!StringVerification.HasLowerCaseLetter(password)) return false;
                        break;
                    case PasswordOption.RequireUppercase:
                        if (!StringVerification.HasUpperCaseLetter(password)) return false;
                        break;
                    case PasswordOption.RequireDigit:
                        if (!StringVerification.HasDigit(password)) return false;
                        break;
                }
            }

            // return true if the password pass all verification;
            return true;
        }
    }
}
