using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.LexicalAnalyzer
{
    public enum WordType
    {
        /// <summary>
        /// 十进制整数
        /// </summary>
        Decimal,
        /// <summary>
        /// 八进制整数
        /// </summary>
        Octonary,
        /// <summary>
        /// 十六进制整数
        /// </summary>
        Hexadecimal,
        /// <summary>
        /// 浮点数
        /// </summary>
        FloatConstant,
        /// <summary>
        /// 字符
        /// </summary>
        CharConstant,
        /// <summary>
        /// 字符串
        /// </summary>
        StringConstant,
        /// <summary>
        /// 标识符
        /// </summary>
        Identifier,
        /// <summary>
        /// 关键字
        /// </summary>
        Keyword,
        /// <summary>
        /// 运算符
        /// </summary>
        Operator,
        /// <summary>
        /// 界符
        /// </summary>
        BoundarySign,
        /// <summary>
        /// 注释
        /// </summary>
        Comment,
        /// <summary>
        /// 不合法的字符串结构
        /// </summary>
        Illegal
    }
}
