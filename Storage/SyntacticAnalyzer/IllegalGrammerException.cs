using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SyntacticAnalyzer
{
    [Serializable]
    public class IllegalGrammerException : Exception
    {
        public IllegalGrammerException() { }

        public IllegalGrammerException(string message)
            : base(message) { }

        public IllegalGrammerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
