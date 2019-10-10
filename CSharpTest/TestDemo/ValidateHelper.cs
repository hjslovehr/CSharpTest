using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDemo
{
    public static class ValidateHelper
    {
        public static bool IsIP(string strIP)
        {
            if (string.IsNullOrWhiteSpace(strIP))
            {
                return false;
            }

            return Regex.IsMatch(strIP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}
