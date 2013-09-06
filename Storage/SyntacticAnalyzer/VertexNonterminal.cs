using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SyntacticAnalyzer
{
    /// <summary>
    /// 文法的非终结符
    /// </summary>
    public class VertexNonterminal : Vertex
    {
        public List<Vertex> Children { get; set; }
        public VertexNonterminal(char name)
            : base(name) { }
    }
}
