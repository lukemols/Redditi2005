using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redditi2005.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsRedditCategory(this string str)
        {
            string s = str.Trim();
            // Always less than two chars and formed by letters
            if (s.Length <= 2)
            {
                foreach (char c in s) 
                {
                    if (Char.IsLetter(c))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsCompanyCategory(this string str)
        {
            string s = str.Trim();
            // Always five chars and formed by letters and numbers. Cannot contains "."
            if (s.Length == 5)
            {
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                    {
                        return true;
                    }
                    else if (Char.IsPunctuation(c))
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public static bool IsNameSurname(this string str)
        {
            string s = str.Trim();
            string[] split = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // we are not brazilian players
            if (split.Length > 1)
            {
                int letters = 0, punctuation = 0;
                
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                    {
                        letters++;
                    }
                    else if (Char.IsPunctuation(c))
                    {
                        punctuation++;
                    }
                    else if (Char.IsNumber(c))
                    {
                        return false; // sorry Elon Musk's son
                    }
                    return letters > punctuation;
                }
            }
            return false;
        }

        public static bool IsBirthday(this string str)
        {
            string s = str.Trim();

            CultureInfo itIT = new CultureInfo("it-IT");
            // Always YYYY-MM-DD
            if (DateTime.TryParseExact(s, "yyyy-MM-dd", itIT, System.Globalization.DateTimeStyles.AssumeLocal, out DateTime date))
            {
                return date.Year > 1900 && date.Year < 2005;
            }
            return false;
        }

        public static int ParseReddit(this string str)
        {
            string s = str.Replace(".", "");
            int.TryParse(s, out int result);
            return result;
        }
    }
}
