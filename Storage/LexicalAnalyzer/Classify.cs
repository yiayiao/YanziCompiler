using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.LexicalAnalyzer
{
    public class Classify
    {
        private static string[] keyWords = { "bool", "true", "false", "char", "int", "long", "short", "float", "double", 
                                    "signed", "unsigned", "void", "const", "sizeof", "if", "else", "switch",
                                    "case", "default", "while", "for", "break", "continue", "return", "goto", 
                                    "static", "extern", "struct", "union", "enum", "typedef", "new", "delete", 
                                    "class", "private", "public", "protected", "this", "operator", 
                                    "friend", "namespace", "using" };

        public static int getValue(WordType state, string content)
        {
            if (state == WordType.Identifier)
            {
                for (int i = 0; i < keyWords.Length; i++)
                    if (content.Equals(keyWords[i]))
                        return i + 1;
            }
            return -1;
        }

    }
}
