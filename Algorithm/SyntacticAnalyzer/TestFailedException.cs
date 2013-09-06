using Storage.SyntacticAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.SyntacticAnalyzer
{
    [Serializable]
    public class TestFailedException : Exception
    {
        public Stack<Vertex> InputStack
        {
            get;
            private set;
        }
        public Stack<ItemSet> StatusStack
        {
            get;
            private set;
        }
        public Stack<Vertex> LetterStack
        {
            get;
            private set;
        }
        public TestFailedException()
        {
        }

        public TestFailedException(string message, Stack<Vertex> inputStack, Stack<ItemSet> statusStack, Stack<Vertex> letterStack)
            : base(message)
        {
            this.InputStack = inputStack;
            this.StatusStack = statusStack;
            this.LetterStack = letterStack;
        }
        public TestFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected TestFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
