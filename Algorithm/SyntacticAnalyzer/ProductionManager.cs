using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.SyntacticAnalyzer;

namespace Algorithm.SyntacticAnalyzer
{
    /// <summary>
    /// 从输入串中得到的产生式
    /// </summary>
    public class ProductionManager
    {
        #region Properties
        public List<VertexNonterminal> VertexNonterminalSet { get; private set; }
        public List<VertexTerminator> VertexTerminatorSet { get; private set; }
        public List<GrammerRule> GrammerRuleSet { get; private set; }
        #endregion

        #region Methods
        private VertexNonterminal AddVertexNonterminal(char vn)
        {
            if (!this.VertexNonterminalSet.Exists(x => x.Name == vn))
            {
                this.VertexNonterminalSet.Add(new VertexNonterminal(vn));
            }
            return this.VertexNonterminalSet.Single(v => v.Name == vn);
        }
        private VertexTerminator AddVertexTerminator(char vt)
        {
            if (!this.VertexTerminatorSet.Exists(x => x.Name == vt))
            {
                this.VertexTerminatorSet.Add(new VertexTerminator(vt));
            }
            return this.VertexTerminatorSet.Single(v => v.Name == vt);
        }
        #endregion

        #region Contructor
        public ProductionManager(string grammerContext, string[] deriver = null)
        {
            this.VertexNonterminalSet = new List<VertexNonterminal>();
            this.VertexTerminatorSet = new List<VertexTerminator>();
            this.GrammerRuleSet = new List<GrammerRule>();

            List<String> textLines = grammerContext.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (textLines.Count == 0)
                throw new IllegalGrammerException("语法为空");

            if (deriver == null)
                deriver = new String[] { "->", "→" };
            

            foreach (var textLine in textLines)
            {
                int iComment = textLines.IndexOf("//");
                string realTextLine = iComment >= 0 ? textLine.Substring(0, iComment) : textLine;
                if (string.IsNullOrWhiteSpace(realTextLine))
                    continue;

                string[] ruleArray = realTextLine.Split(deriver, StringSplitOptions.RemoveEmptyEntries);
                if (ruleArray == null)
                    throw new IllegalGrammerException("无法分析的产生式");

                string strLeft = ruleArray[0];
                string[] strRights = ruleArray[1].Split('|');
                if (strLeft.Length != 1 || strLeft.ToUpper() != strLeft)
                    throw new IllegalGrammerException("推导符左边应该为一个大写字母作为非终结符");

                VertexNonterminal ruleLeft = this.AddVertexNonterminal(strLeft[0]);
                foreach (string strRight in strRights)
                {
                    List<Vertex> ruleRight = new List<Vertex>();
                    foreach (char charVertex in strRight)
                    {
                        if ('A' <= charVertex && charVertex <= 'Z')
                            ruleRight.Add(this.AddVertexNonterminal(charVertex));
                        else
                            ruleRight.Add(this.AddVertexTerminator(charVertex));
                    }
                    GrammerRule newRule = new GrammerRule(ruleLeft, ruleRight);
                    newRule.IsAcceptRule = false;
                    this.GrammerRuleSet.Add(newRule);
                }
            }

            if (this.GrammerRuleSet.Count == 0)
            {
                throw new IllegalGrammerException("语法为空");
            }

            this.VertexTerminatorSet.Add(VertexTerminator.End);
            this.GrammerRuleSet[0].IsAcceptRule = true;
        }
        #endregion

        #region First Set Calculation
        private Dictionary<VertexNonterminal, List<VertexTerminator>> first;
        private List<VertexTerminator> getFirst(VertexNonterminal vn)
        {
            if (this.first.ContainsKey(vn))
                return this.first[vn];

            List<VertexTerminator> ret = new List<VertexTerminator>();
            IEnumerable<GrammerRule> rulesAboutVn = this.GrammerRuleSet.Where(x => x.Left == vn);
            foreach (GrammerRule rule in rulesAboutVn)
            {
                var firstv = rule.Right[0];
                if (firstv.GetType() == typeof(VertexNonterminal))
                {
                    if (firstv != vn)
                    {
                        ret.AddRange(getFirst((VertexNonterminal)firstv));
                    }
                }
                else
                {
                    if (!ret.Contains(firstv))
                        ret.Add((VertexTerminator)firstv);
                }
            }
            if (!this.first.ContainsKey(vn))
                this.first.Add(vn, ret);
            return ret;
        }

        public Dictionary<VertexNonterminal, List<VertexTerminator>> First
        {
            get
            {
                if (this.first == null)
                {
                    first = new Dictionary<VertexNonterminal, List<VertexTerminator>>();
                    foreach (var vn in this.VertexNonterminalSet)
                    {
                        getFirst(vn);
                    }
                }
                return first;
            }
        }
        #endregion
    }
}
