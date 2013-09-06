using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SyntacticAnalyzer
{
    /// <summary>
    /// 文法的终结符
    /// </summary>
    public class VertexTerminator : Vertex
    {
        public static readonly VertexTerminator End = new VertexTerminator('#', true);

        public bool IsEnd { get; set; }

        public VertexTerminator(char name, bool isEnd = false)
            : base(name)
        {
            this.IsEnd = IsEnd;
        }
    }
}
