using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.LexicalAnalyzer
{
    public enum ExceptionType
    {
        /// <summary>
        /// 非法的转义字符
        /// </summary>
        EscapeCharacterException,
        /// <summary>
        /// 非法字符
        /// </summary>
        InvalidCharacterException,
        /// <summary>
        /// 没有结束的注释
        /// </summary>
        CommentException
    }
}
