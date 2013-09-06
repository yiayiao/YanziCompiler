using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.SyntacticAnalyzer;

namespace Algorithm.SyntacticAnalyzer
{
    public abstract class Action
    {
        public virtual bool IsConflicWith(Action action)
        {
            return this.GetType() != action.GetType();
        }
    }

    /// <summary>
    /// 移进
    /// </summary>
    public class GotoAction : Action
    {
        public ItemSet ItemSet { get; set; }
        public override string ToString()
        {
            return String.Format("{0}", ItemSet);
        }
    }

    /// <summary>
    /// 规约
    /// </summary>
    public class ConvertionAction : Action
    {
        public GrammerRule Rule { get; set; }
        public Boolean Acceptable { get; set; }

        public ConvertionAction()
        {
            this.Acceptable = false;
        }
        public override bool IsConflicWith(Action action)
        {
            return base.IsConflicWith(action) || this.Rule != ((ConvertionAction)action).Rule;
        }
        public override string ToString()
        {
            return String.Format("{0}", Rule);
        }
    }
}
