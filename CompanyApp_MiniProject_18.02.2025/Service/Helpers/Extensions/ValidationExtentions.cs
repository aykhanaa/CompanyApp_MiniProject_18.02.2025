
using System.Text.RegularExpressions;


namespace Service.Helpers.Extensions
{
    public  static class ValidationExtentions
    {
        public static bool CheckNameFormat(this string name)
        {
            return Regex.IsMatch(name, @"^[\p{L}]+(?:\s[\p{L}]+)?$");
        }
        public static bool CheckFullNameFormat(this string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z]+([ ]?[A-Za-z]+)*$");
        }
        public static bool CheckEmailFormat(this string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
        public static bool CheckPasswordFormat(this string name)
        {
            return Regex.IsMatch(name, @"^(?=.*\d).{3,}$");
        }

        public static bool CheckAddressFormat(this string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+[0-9]*$");
        }

        public static bool CheckNameFormatAllowSpace(this string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z\s]+$");
        }



    }
}
