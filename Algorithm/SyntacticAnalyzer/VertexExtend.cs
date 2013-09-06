using Storage.SyntacticAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.SyntacticAnalyzer
{
    public static class VertexExtend
    {
        public static Vertex UniformBy(this Vertex v, ProductionManager g)
        {
            if (v.GetType() == typeof(VertexTerminator))
            {
                return g.VertexTerminatorSet.SingleOrDefault(c => c.Name == v.Name);
            }
            else if (v.GetType() == typeof(VertexNonterminal))
            {
                return g.VertexNonterminalSet.SingleOrDefault(c => c.Name == v.Name);
            }
            return null;
        }
    }
}
