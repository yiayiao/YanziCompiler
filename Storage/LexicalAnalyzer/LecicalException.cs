using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Storage.LexicalAnalyzer
{
    [Serializable]
    public class LecicalException : Exception
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public ExceptionType Type { get; private set; }
        /// <summary>
        /// 已读到字符串内容
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// 首字母所在行
        /// </summary>
        public int Row { get; private set; }
        /// <summary>
        /// 首字母所在列
        /// </summary>
        public int Column { get; private set; }
        /// <summary>
        /// 首字母在文本中位置
        /// </summary>
        public int Index { get; private set; }


        public LecicalException() { }
        public LecicalException(ExceptionType type, string message = null)
            : base(message)
        {
            this.Type = type;
        }
        public LecicalException(ExceptionType type, string content, int row, int column, int index, string message = null)
            : base(message)
        {
            this.Type = type;
            this.Content = content;
            this.Row = row;
            this.Column = column;
            this.Index = index;
        }
        public LecicalException(string message, Exception inner) : base(message, inner) { }
        protected LecicalException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }
}
