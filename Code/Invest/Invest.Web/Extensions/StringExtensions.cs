using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extensions.String
{
    public static class StringExtensions
    {
        public static string ToJSONString(this string text)
        {
            char[] charArray = text.ToCharArray();
            List<string> output = new List<string>();
            foreach (char c in charArray)
            {
                if (((int)c) == 8)              //Backspace
                    output.Add("\\b");
                else if (((int)c) == 9)         //Horizontal tab
                    output.Add("\\t");
                else if (((int)c) == 10)        //Newline
                    output.Add("\\n");
                else if (((int)c) == 12)        //Formfeed
                    output.Add("\\f");
                else if (((int)c) == 13)        //Carriage return
                    output.Add("\\n");
                else if (((int)c) == 34)        //Double-quotes (")
                    output.Add("\\" + c.ToString());
                else if (((int)c) == 47)        //Solidus   (/)
                    output.Add("\\" + c.ToString());
                else if (((int)c) == 92)        //Reverse solidus   (\)
                    output.Add("\\" + c.ToString());
                else if (((int)c) > 31)
                    output.Add(c.ToString());
                //TODO: add support for hexadecimal
            }
            return string.Join("", output.ToArray()) ;
        }


        /// <summary>
        /// Cắt chuỗi với n ký tự
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nCount">Số ký tự muốn lấy</param>
        /// <returns></returns>
        public static string ToStringCount(this string text,int nCount)
        {
            if (text == null)
                return text;
            if (text.Length >= nCount)
                text = text.Substring(0, nCount) + " ...";
            return text;
        }
    }
}