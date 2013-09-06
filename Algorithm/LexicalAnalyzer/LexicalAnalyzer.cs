using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.LexicalAnalyzer;

namespace Algorithm.LexicalAnalyzer
{
    public class LexicalAnalyzer
    {
        public string Content { get; private set; }
        private int startPoint, readerPoint;
        private DFA dfa;
        private Classify classify;

        public LexicalAnalyzer(string content)
        {
            this.Content = content.Replace("\r", "");
            this.dfa = new DFA();
            this.classify = new Classify();
            this.startPoint = this.readerPoint = 0;
        }

        public void Analyses(out List<Token> tokenList, out List<string> errorList)
        {
            tokenList = new List<Token>();
            errorList = new List<string>();

            while (readerPoint < Content.Length)
            {
                if (dfa.bufferSize < 2)
                {
                    dfa.InputChar(this.NextChar());
                    if (readerPoint < Content.Length)
                        dfa.InputChar(this.NextChar());
                }
                try
                {
                    if (dfa.bufferSize >= 2)
                    {
                        dfa.Convert();
                        AddToken(ref tokenList);
                    }
                }
                catch (LecicalException e)
                {
                    string error = string.Format("error({0}, {1}): {2} {3}", e.Row, e.Column, e.Content, e.Message);
                    errorList.Add(error);
                    continue;
                }
            }
            while (dfa.bufferSize > 0)
            {
                try
                {
                    dfa.Convert();
                    AddToken(ref tokenList);
                }
                catch (LecicalException e)
                {
                    string error = string.Format("error({0}, {1}): {2} {3}", e.Row, e.Column, e.Content, e.Message);
                    errorList.Add(error);
                    continue;
                }
            }
        }

        private void AddToken(ref List<Token> tokenList)
        {
            if (dfa.endState)
            {
                while (Content[startPoint] == ' ' || Content[startPoint] == '\t' || Content[startPoint] == '\n'
                    || Content[startPoint] == '"' || Content[startPoint] == '\'')
                {
                    startPoint++;
                }
                Token token = new Token();
                dfa.getToken(ref token);    //token.Content, token.type, token.value赋值
                token.Row = Content.GetRow(startPoint);
                token.Column = Content.GetColumn(startPoint);
                token.Id = tokenList.Count + 1;
                token.Index = startPoint;
                tokenList.Add(token);
                startPoint += token.Content.Length;
            }
        }

        private char NextChar()
        {
            if (readerPoint < Content.Length)
            {
                return Content[readerPoint++];
            }
            throw new Exception("out of boundary");
        }

        private char CurrentChar()
        {
            if (readerPoint > 0)
            {
                return Content[readerPoint - 1];
            }
            throw new Exception("out of boundary");
        }
    }
}
