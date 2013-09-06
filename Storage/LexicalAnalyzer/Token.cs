using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.LexicalAnalyzer
{
    public class Token
    {
        /// <summary>
        /// 单词标号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 单词种类
        /// </summary>
        public WordType Type { get; set; }
        /// <summary>
        /// 单词内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 首字母所在行
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// 首字母所在列
        /// </summary>
        public int Column { get; set; }
        /// <summary>
        /// 首字母在文本中位置
        /// </summary>
        public int Index { get; set; }

        public Token() { }
        public Token(WordType type, string content, int value, int row, int column, int index)
        {
            this.Type = type;
            this.Value = value;
            this.Row = row;
            this.Column = column;
            this.Content = content;
            this.Index = index;
        }
    }
}
