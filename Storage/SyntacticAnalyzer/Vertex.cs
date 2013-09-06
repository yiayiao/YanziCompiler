using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SyntacticAnalyzer
{
    public class Vertex
    {
        public char Name
        {
            get;
            private set;
        }
        public VertexNonterminal Father { get; set; }
        public int Depth { get; set; }

        public Vertex(char name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
