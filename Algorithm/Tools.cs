using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.LexicalAnalyzer
{
    public static class Tools
    {
        /// <summary>
        /// 返回字符在字符串中的行号
        /// </summary>
        /// <param name="index">字符位置</param>
        public static int GetRow(this string s, int index)
        {
            if (index >= s.Length)
            {
                throw new Exception("index out of boundary");
            }
            if (s[index] == '\n')
            {
                throw new Exception("this is the end of line");
            }
            int cnt = 1;
            for (int i = 0; i <= index; i++)
            {
                if (s[i] == '\n')
                {
                    cnt++;
                }
            }
            return cnt;
        }

        /// <summary>
        /// 返回字符在字符串中的列号
        /// </summary>
        /// <param name="index">字符位置</param>
        public static int GetColumn(this string s, int index)
        {
            if (index >= s.Length)
            {
                throw new Exception("index out of boundary");
            }
            if (s[index] == '\n')
            {
                throw new Exception("this is the end of line");
            }
            int i;
            for (i = index; i >= 0; i--)
            {
                if (s[i] == '\n')
                {
                    break;
                }
            }
            return index - i;
        }
    }
}
