using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Invest.Web
{
    public static class StringExtensions
    {
        public static string ConvertToUnSign(this string s)
        {
            s = HttpUtility.UrlEncode(s);
            if (s == null)
                return s;
            s = s.ToLower().Replace("%e2%80%93", "").Replace("%c2%", "");
            s = HttpUtility.UrlDecode(s);
            var stFormD = s.Trim().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var t in stFormD)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }
            //URL REWRITE

            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            sb = sb.Replace('!', ' ');
            sb = sb.Replace('$', ' ');
            sb = sb.Replace('#', ' ');
            sb = sb.Replace(':', ' ');
            sb = sb.Replace(';', ' ');
            sb = sb.Replace('&', ' ');
            sb = sb.Replace('=', ' ');
            sb = sb.Replace('/', ' ');
            sb = sb.Replace('|', ' ');
            sb = sb.Replace('*', ' ');
            sb = sb.Replace('%', ' ');
            sb = sb.Replace('.', ' ');
            sb = sb.Replace(',', ' ');
            sb = sb.Replace('"', ' ');
            sb = sb.Replace('“', ' ');
            sb = sb.Replace('”', ' ');
            sb = sb.Replace('\'', ' ');
            sb = sb.Replace('?', ' ');
            sb = sb.Replace('-', ' ');
            sb = sb.Replace('+', ' ');
            sb = sb.Replace('(', ' ');
            sb = sb.Replace(')', ' ');
            sb = sb.Replace('[', ' ');
            sb = sb.Replace(']', ' ');
            sb = sb.Replace('.', ' ');
            sb = sb.Replace(' ', '-');
            return TrimSpace(sb.ToString().ToLower().Trim('-').Normalize(NormalizationForm.FormD), "-");
        }

        public static string TrimSpace(string s, string strSplit)
        {

            s = s.Trim();
            s = s.Trim('-');
            try
            {
                for (var i = 0; i < s.Length - 1; i++)
                {
                    while (s.Substring(i, 1) == strSplit && s.Substring(i + 1, 1) == strSplit)
                        s = s.Remove(i, 1);
                }
            }
            catch
            {
                return s;
            }

            return s;
        }
    }
}