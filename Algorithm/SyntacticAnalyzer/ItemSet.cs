using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.SyntacticAnalyzer;

namespace Algorithm.SyntacticAnalyzer
{
    public class ItemSet
    {
        /// <summary>
        /// family的引用，监听者模式
        /// </summary>
        private ItemFamily family;
        /// <summary>
        /// 该ItemSet所含的Item
        /// </summary>
        private List<Item> items = new List<Item>();
        /// <summary>
        /// 算符与动作的对应表
        /// </summary>
        private Dictionary<Vertex, Action> actionTable;

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public Dictionary<Vertex, Action> ActionTable
        {
            get
            {
                if (actionTable == null)
                {
                    actionTable = new Dictionary<Vertex, Action>();
                    CalcAction();   //
                }
                return actionTable;
            }
        }

        public int Index
        {
            get
            {
                return this.family.AllItemSet.IndexOf(this);
            }
        }

        public void SetFamily(ItemFamily family)
        {
            this.family = family;
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        #region 一系列的计算与赋值操作
        /// <summary>
        /// 计算actionTable，产生下一步的ItemSet
        /// </summary>
        private void CalcAction()
        {
            foreach (Item project in this.items)
            {
                if (project.Type == ProjectType.Convention)
                {
                    BuildConvertionAction(project); //规约项
                }
                else
                {
                    BuildGotoAction(project);   //移进项
                }
            }
            //检查生产的GotoAction所指的项目是否存在
            foreach (var GotoActionItem in actionTable.Where(c => c.Value.GetType() == typeof(GotoAction)))
            {
                GotoAction gotoAction = (GotoAction)GotoActionItem.Value;
                bool exist = false;
                foreach (ItemSet itemSet in this.family.AllItemSet)
                {
                    if (gotoAction.ItemSet.IsSameWith(itemSet))// 已经存在，直接指向已有的项目
                    {
                        gotoAction.ItemSet = itemSet;
                        exist = true;
                        break;
                    }
                }
                if (!exist) //将转移后的ItemSet注册到family中，family将会调用CaluClosure计算闭包
                {
                    this.family.Register(gotoAction.ItemSet);
                }
            }
        }

        #region 状态转移,规约与移进
        private void BuildConvertionAction(Item project)
        {
            ConvertionAction action = new ConvertionAction()    //规约
            {
                Rule = project.Rule
            };

            foreach (VertexTerminator vter in project.FowardSearch)
            {
                if (this.actionTable.ContainsKey(vter))
                {
                    if (actionTable[vter].IsConflicWith(action)) //待规约的actionTable只能有一个Item
                        throw new Exception(String.Format("在 {0} 遇到 {1} 产生冲突：{2} 和 {3}", this, vter, actionTable[vter], action));
                }
                else
                {
                    if (project.Rule.IsAcceptRule)
                        action.Acceptable = true;
                    this.actionTable.Add(vter, action);
                }
            }
        }

        private void BuildGotoAction(Item project)
        {
            GotoAction action = new GotoAction();   //移进
            Vertex vert = project.AfterDot(0);
            Item proAfterShift = project.Shift();
            proAfterShift.IsCore = true;

            if (actionTable.ContainsKey(vert))
            {
                if (actionTable[vert].IsConflicWith(action))
                    throw new Exception(String.Format("在 {0} 遇到 {1} 产生冲突：{2} 和 {3}", this, vert, actionTable[vert], action));
                action = (GotoAction)actionTable[vert];
                action.ItemSet.items.Add(proAfterShift);
            }
            else
            {
                action.ItemSet = new ItemSet();
                action.ItemSet.items.Add(proAfterShift);
                this.actionTable.Add(vert, action);
            }
        }
        #endregion

        /// <summary>
        /// 计算闭包，宽搜，在this.family.Register中被调用
        /// </summary>
        public void CalcClosure()
        {
            Queue<Item> queue = new Queue<Item>();
            //所有圆点后为非终结符的项目入队
            foreach (Item coreItem in this.items.Where(c => c.IsCore))
            {
                if (coreItem.AfterDot(0) != null && coreItem.AfterDot(0).GetType() == typeof(VertexNonterminal))
                {
                    queue.Enqueue(coreItem);
                }
            }
            while (queue.Count > 0) //宽搜
            {
                Item itemjToExpand = queue.Dequeue();
                VertexNonterminal vnToExpand = (VertexNonterminal)itemjToExpand.AfterDot(0);
                IEnumerable<GrammerRule> rulesForExpanding = this.family.Grammer.GrammerRuleSet.Where(c => c.Left == vnToExpand);
                
                foreach (GrammerRule r in rulesForExpanding)
                {
                    // 生成可能添加的project
                    Item projExpand = new Item()
                    {
                        Rule = r,
                        DotPosition = 0,
                        FowardSearch = GetFowardSearch(itemjToExpand, this.family.Grammer),
                        IsCore = false
                    };
                    Boolean projExist = false;
                    // 检查项目是否存在
                    foreach (Item projCurrent in this.items)
                    {
                        if (projCurrent.IsSameItemWith(projExpand))
                        {
                            // 存在则合并向前搜索符
                            projCurrent.CombineFowardSearch(projExpand);
                            projExist = true;
                            break;
                        }
                    }
                    if (!projExist)
                    {
                        // 不存在则添加，如果是非终结符开始，还需加到队列里
                        this.items.Add(projExpand);
                        if (projExpand.AfterDot(0).GetType() == typeof(VertexNonterminal))
                        {
                            queue.Enqueue(projExpand);
                        }
                    }
                }
            }
        }
        #endregion


        /// <summary>
        /// 合并同心集
        /// </summary>
        /// <param name="itemSetToCombine">待合并的同心集</param>
        /// <returns></returns>
        public bool CombineBySameCore(ItemSet itemSetToCombine)
        {
            if (!this.IsSameCoreWith(itemSetToCombine))
                return false;

            //合并向前搜索符
            foreach (Item item in this.items)
            {
                Item itemToCombine = itemSetToCombine.items.SingleOrDefault(c => c.IsSameItemWith(item));
                item.CombineFowardSearch(itemToCombine);
            }
            //合并actionItem
            foreach (var actionItem in itemSetToCombine.actionTable)
            {
                if (!this.actionTable.ContainsKey(actionItem.Key))
                    this.actionTable.Add(actionItem.Key, actionItem.Value);
            }
            //修改family项目集中的action指向，去除对将移除的itemSet的指向
            foreach (ItemSet itemToReplace in this.family.AllItemSet)
            {
                foreach (var action in itemToReplace.ActionTable)
                {
                    if (action.Value.GetType() == typeof(GotoAction))
                    {   
                        var gotoAction = (GotoAction)action.Value;
                        if (gotoAction.ItemSet == itemSetToCombine)
                            gotoAction.ItemSet = this;
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// 获取向前推导符
        /// </summary>
        /// <param name="proToExpand"></param>
        /// <param name="grammer"></param>
        /// <returns></returns>
        private List<VertexTerminator> GetFowardSearch(Item projToExpand, ProductionManager grammer)
        {
            List<VertexTerminator> ret = new List<VertexTerminator>();
            int i = 1;
            Vertex vCurrent = projToExpand.AfterDot(i);
            if (vCurrent == null)
                return new List<VertexTerminator>(projToExpand.FowardSearch);

            while (vCurrent != null)
            {
                if (vCurrent.GetType() == typeof(VertexTerminator))
                {
                    ret.Add((VertexTerminator)vCurrent);
                    break;
                }
                else
                {
                    List<VertexTerminator> first = grammer.First[(VertexNonterminal)vCurrent];
                    ret.AddRange(first);
                    if (first.Contains(null) == false)
                        break;
                }
                vCurrent = projToExpand.AfterDot(++i);
            }
            return ret;
        }

        /// <summary>
        /// 两个itemSet完全一致，包括向前搜索符
        /// </summary>
        /// <param name="itemSet">ItemSet</param>
        /// <returns>两个ItemSet是否完全一样</returns>
        public bool IsSameWith(ItemSet itemSet)
        {
            IEnumerable<Item> core1, core2;
            core1 = this.items.Where(c => c.IsCore);
            core2 = itemSet.items.Where(c => c.IsCore);
            if (core1.Count() != core2.Count())
                return false;
            foreach (Item p1 in core1)
            {
                if (core2.SingleOrDefault(c => c.isCompleteSameWith(p1)) == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 不要求向前的推导符也一致
        /// </summary>
        /// <param name="itemSet"></param>
        /// <returns></returns>
        public bool IsSameCoreWith(ItemSet itemSet)
        {
            IEnumerable<Item> core1, core2;
            core1 = this.items.Where(c => c.IsCore);
            core2 = itemSet.items.Where(c => c.IsCore);
            if (core1.Count() != core2.Count())
                return false;
            foreach (Item p1 in core1)
            {
                if (core2.SingleOrDefault(c => c.IsSameItemWith(p1)) == null)
                    return false;
            }
            return true;
        }



        public override string ToString()
        {
            string ret = "";
            var sameCore = this.family.AllItemSet.Where(c => c.IsSameCoreWith(this));

            ret = "I" + this.Index;
            if (sameCore.Count() > 1)
            {
                ret += "(";
                foreach (var item in sameCore)
                    ret += +item.Index + ",";
                ret = ret.Substring(0, ret.Length - 1) + ")";
            }
            return ret;
        }
    }
}
