using Storage.LexicalAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.LexicalAnalyzer
{
    public class DFA
    {

        private WordType status;
        private Queue<char> bufferQue;
        public string content { get; set; }
        public bool beginState { get; set; }
        public bool endState { get; set; }
        public int bufferSize
        {
            get
            {
                return bufferQue.Count;
            }
        }

        public void init()
        {
            beginState = true;
            endState = false;
            content = "";
        }

        public DFA()
        {
            bufferQue = new Queue<char>();
            init();
        }

        public void InputChar(char c)
        {
            bufferQue.Enqueue(c);
        }

        public void getToken(ref Token token)
        {
            token.Type = status;
            token.Content = this.content;
            if (status == WordType.Identifier)
            {
                int retVal = Classify.getValue(WordType.Identifier, content);
                if (retVal != -1)
                {
                    token.Type = WordType.Keyword;
                    token.Value = retVal;
                }
            }
            init();
        }

        #region 状态转移
        private void convertToState(WordType type, char c)
        {
            status = type;
            content += c;
        }

        private void beginConvert(char fir_c, char sec_c)
        {
            string tmp = string.Format("{0}{1}", fir_c, sec_c);
            if (tmp == "!=" || tmp == "==" || tmp == "++" || tmp == "--" || tmp == "%=" || tmp == "&="
                || tmp == "+=" || tmp == "-=" || tmp == "*=" || tmp == "^=" || tmp == "/=" || tmp == "^=")
            {
                status = WordType.Operator;
                content = tmp;
                bufferQue.Dequeue();
                endState = true;
            }
            else if (tmp == "//" || tmp == "/*")
            {
                status = WordType.Comment;
                content = tmp;
                bufferQue.Dequeue();
            }
            else if (tmp == "0x" || tmp == "0X")
            {
                convertToState(WordType.Hexadecimal, fir_c);
            }
            else if (fir_c == '"')
            {
                status = WordType.StringConstant;
                if (sec_c == '"')
                {
                    bufferQue.Dequeue();
                    endState = true;
                }
            }
            else if (fir_c == '\'')
            {
                convertToState(WordType.CharConstant, fir_c);
                if (sec_c == '\'')
                {
                    convertToState(WordType.Illegal, sec_c);
                    bufferQue.Dequeue();
                    endState = true;
                }
            }
            else if (fir_c == '0')
            {
                if (sec_c < '7' && sec_c > '0')
                {
                    convertToState(WordType.Octonary, fir_c);
                }
                else if (isLetter(sec_c))
                {
                    convertToState(WordType.Illegal, fir_c);
                }
                else if (sec_c == '.')
                {
                    convertToState(WordType.FloatConstant, fir_c);
                }
                else
                {
                    convertToState(WordType.Decimal, fir_c);
                    endState = true;
                }
            }
            else if (isNumber(fir_c))
            {
                if (sec_c == '.')
                {
                    convertToState(WordType.FloatConstant, fir_c);
                }
                else if (isLetter(sec_c))
                {
                    convertToState(WordType.Illegal, fir_c);
                }
                else if (isNumber(sec_c))
                {
                    convertToState(WordType.Decimal, fir_c);
                }
                else
                {
                    convertToState(WordType.Decimal, fir_c);
                    endState = true;
                }
            }
            else if (isLetter(fir_c))
            {
                if (isLetter(sec_c) || isNumber(sec_c) || sec_c == '_')
                {
                    convertToState(WordType.Identifier, fir_c);
                }
                else
                {
                    convertToState(WordType.Identifier, fir_c);
                    endState = true;
                }
            }
            else if (fir_c == '{' || fir_c == '}' || fir_c == ';')
            {
                convertToState(WordType.BoundarySign, fir_c);
                endState = true;
            }
            else
            {
                convertToState(WordType.Operator, fir_c);
                endState = true;
            }
        }

        private void continueConvert(char fir_c, char sec_c)
        {
            switch (status)
            {
                case WordType.Comment:
                    if (content.StartsWith("/*") && string.Format("{0}{1}", fir_c, sec_c).Equals("*/"))
                    {
                        content += fir_c;
                        content += sec_c;
                        bufferQue.Dequeue();
                        endState = true;
                    }
                    else if (sec_c == '\n' && !content.StartsWith("/*"))
                    {
                        content += fir_c;
                        endState = true;
                    }
                    else
                    {
                        convertToState(WordType.Comment, fir_c);
                    }
                    break;
                case WordType.StringConstant:
                    convertToState(WordType.StringConstant, fir_c);
                    if (sec_c == '"')
                    {
                        bufferQue.Dequeue();
                        endState = true;
                    }
                    break;
                case WordType.CharConstant:
                    convertToState(WordType.CharConstant, fir_c);
                    if (sec_c == '\'')
                    {
                        content.Substring(1);
                        if (content.Length > 1)
                            status = WordType.Illegal;
                        bufferQue.Dequeue();
                        endState = true;
                    }
                    break;
                case WordType.Decimal:
                    if (sec_c == '.')
                    {
                        convertToState(WordType.FloatConstant, fir_c);
                    }
                    else if (isNumber(sec_c))
                    {
                        convertToState(WordType.Decimal, fir_c);
                    }
                    else if (isLetter(sec_c) || sec_c == '_')
                    {
                        convertToState(WordType.Illegal, fir_c);
                    }
                    else
                    {
                        convertToState(WordType.Decimal, fir_c);
                        endState = true;
                    }
                    break;
                case WordType.FloatConstant:
                    if (isNumber(sec_c))
                    {
                        convertToState(WordType.FloatConstant, fir_c);
                    }
                    else if (isLetter(sec_c) || sec_c == '.')
                    {
                        convertToState(WordType.Illegal, fir_c);
                    }
                    else
                    {
                        convertToState(WordType.FloatConstant, fir_c);
                        endState = true;
                    }
                    break;
                case WordType.Hexadecimal:
                    if (isNumber(sec_c) || ('a' <= sec_c && sec_c <= 'f') || ('A' <= sec_c && sec_c <= 'F'))
                    {
                        convertToState(WordType.Hexadecimal, fir_c);
                    }
                    else if (isLetter(sec_c))
                    {
                        convertToState(WordType.Illegal, fir_c);
                    }
                    else
                    {
                        convertToState(WordType.Hexadecimal, fir_c);
                        endState = true;
                        if (content.Equals("0X") || content.Equals("0x"))
                            status = WordType.Illegal;
                    }
                    break;
                case WordType.Octonary:
                    if ('0' <= sec_c && sec_c <= '8')
                    {
                        convertToState(WordType.Octonary, fir_c);
                    }
                    else if (isNumber(sec_c) || isLetter(sec_c))
                    {
                        convertToState(WordType.Illegal, fir_c);
                    }
                    else
                    {
                        convertToState(WordType.Octonary, fir_c);
                        endState = true;
                        if (content.StartsWith("00"))
                            status = WordType.Illegal;
                    }
                    break;
                case WordType.Illegal:
                    if (isNumber(sec_c) || isLetter(sec_c))
                    {
                        convertToState(WordType.Illegal, fir_c);
                    }
                    else
                    {
                        convertToState(WordType.Illegal, fir_c);
                        endState = true;
                    }
                    break;
                case WordType.Identifier:
                    if (isLetter(sec_c) || isLetter(sec_c))
                    {
                        convertToState(WordType.Identifier, fir_c);
                    }
                    else
                    {
                        convertToState(WordType.Identifier, fir_c);
                        endState = true;
                    }
                    break;
                default: break;
            }
        }

        public void Convert()
        {
            char fir_c = bufferQue.Dequeue(), sec_c = '\n';
            if (bufferQue.Count > 0)
                sec_c = bufferQue.First();

            if (status != WordType.Comment && !isCharValid(fir_c))
            {
                throw new LecicalException(ExceptionType.InvalidCharacterException);
            }
            else if (isEndState(fir_c))
            {
                if (!beginState)
                    endState = true;
            }
            else if (beginState)   //由初始状态开始转移,由转移的前两个字符基本可以断定类型
            {
                beginState = false;
                beginConvert(fir_c, sec_c);
            }
            else
            {
                continueConvert(fir_c, sec_c);
            }
        }
        #endregion






        #region 对合法字符(32<=c<=126, c!='$', c!='@', c!='`'），数字，字母的判别
        private bool isCharValid(char c)
        {
            if (c == '\n' || c == '\t')
                return true;
            if (32 <= c && c <= 126 && c != 36 && c != 64 && c != 96)
                return true;
            return false;
        }

        private bool isNumber(char c)
        {
            if ('0' <= c && c <= '9')
                return true;
            return false;
        }

        private bool isLetter(char c)
        {
            if ('a' <= c && c <= 'z' || 'A' <= c && c <= 'Z' || c == '_')
                return true;
            return false;
        }

        private bool isEndState(char c)
        {
            if (c == ' ' || c == '\t' || c == '\n')
                return true;
            return false;
        }

        private bool isBoundary(char c)
        {
            if (c == ';' || c == '{' || c == '}')
                return true;
            return false;
        }


        #endregion

    }
}
