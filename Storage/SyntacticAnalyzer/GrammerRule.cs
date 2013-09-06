using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SyntacticAnalyzer
{
    /// <summary>
    /// 语法推导式
    /// </summary>
    public class GrammerRule
    {
        private VertexNonterminal left;
        private List<Vertex> right;

        public bool IsAcceptRule { get; set; }
        public VertexNonterminal Left
        {
            get
            {
                return this.left;
            }
        }
        public List<Vertex> Right
        {
            get
            {
                return this.right;
            }
        }
        
        public GrammerRule(VertexNonterminal left, List<Vertex> right)
        {
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            string ret = this.left.ToString() + "->";
            foreach(var v in right)
            {
                ret += v.ToString();
            }
            return ret;
        }

    }
}
