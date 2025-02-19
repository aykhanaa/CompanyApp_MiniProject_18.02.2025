using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public  static class ValidationExtentions
    {
        public static bool CheckCategoryNameFormat(this string name)
        {
            return Regex.IsMatch(name, @"^[\p{L}]+(?:\s[\p{L}]+)?$");
        }

        public static bool IsCorrectProductNameFormat(this string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$");
        }

        public static bool OnlyNumberFormat(this string number)
        {
            return Regex.IsMatch(number, @"^\d+$");
        }

    }
}
