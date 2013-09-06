using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.SyntacticAnalyzer;

namespace Algorithm.SyntacticAnalyzer
{
    public class Analyzer
    {
        private ProductionManager grammer;
        private bool noSameCore = false;

        public delegate void AnalysisProcess(Stack<ItemSet> statusStack, Stack<Vertex> letterStack, Stack<Vertex> inputStack, Action action);
        public AnalysisProcess OnAnalysisProcess;

        public ItemFamily ItemFamily { get; set; }
        public ProductionManager Grammer
        {
            get
            {
                return grammer;
            }
        }

        public Analyzer(ProductionManager grammer)
        {
            if (grammer == null)
                throw new ArgumentNullException("grammer");
            this.grammer = grammer;
        }

        public void Analyze()
        {
            Item firstItem = new Item()
            {
                Rule = grammer.GrammerRuleSet[0],
                DotPosition = 0,
                IsCore = true,
                FowardSearch = new List<VertexTerminator>()
				{
					VertexTerminator.End
				}
            };
            ItemSet firstItemSet = new ItemSet();
            firstItemSet.AddItem(firstItem);

            ItemFamily itemFamily = new ItemFamily(grammer);
            itemFamily.FirstItemSet = firstItemSet;
            itemFamily.Register(firstItemSet);


            Queue<ItemSet> queue = new Queue<ItemSet>();
            queue.Enqueue(firstItemSet);


            int maxIndex = 0;
            while (queue.Count > 0)
            {
                ItemSet currentItemSet = queue.Dequeue();

                foreach (var actionItem in currentItemSet.ActionTable)
                {
                    var v = actionItem.Key;
                    var action = actionItem.Value;
                    if (action.GetType() == typeof(GotoAction))
                    {
                        GotoAction gotoAction = (GotoAction)action;
                        if (gotoAction.ItemSet.Index > maxIndex)
                            queue.Enqueue(gotoAction.ItemSet);
                        maxIndex = Math.Max(maxIndex, gotoAction.ItemSet.Index);
                    }
                }
            }
            this.ItemFamily = itemFamily;
        }


        public void CombineBySameCore()
        {
            if (!noSameCore)
            {
                this.ItemFamily.CombineSameCoreItems();
                noSameCore = true;
            }
        }

        public VertexNonterminal Test(string input)
        {
            Stack<Vertex> inputStack = new Stack<Vertex>();
            inputStack.Push(VertexTerminator.End);
            for (int i = input.Length - 1; i >= 0; i--)
                inputStack.Push(new VertexTerminator(input[i]));

            Stack<ItemSet> statusStack = new Stack<ItemSet>();
            Stack<Vertex> letterStack = new Stack<Vertex>();
            statusStack.Push(this.ItemFamily.FirstItemSet);
            letterStack.Push(VertexTerminator.End);

            while (true)
            {
                ItemSet currentStatus = statusStack.Peek();
                Vertex currentInput = inputStack.Peek().UniformBy(grammer);
                if (currentInput == null)
                    throw new TestFailedException("输入'" + inputStack.Peek() + "'符号不合法", inputStack, statusStack, letterStack);

                if (currentStatus.ActionTable.ContainsKey(currentInput) == false)
                    throw new TestFailedException("无法找到合适的规约项或者移进项", inputStack, statusStack, letterStack);

                Action action = currentStatus.ActionTable[currentInput];

                if (OnAnalysisProcess != null && currentInput.GetType() == typeof(VertexTerminator))
                    OnAnalysisProcess(statusStack, letterStack, inputStack, action);

                if (action.GetType() == typeof(GotoAction))
                {
                    letterStack.Push(inputStack.Pop());
                    statusStack.Push(((GotoAction)action).ItemSet);
                }
                else
                {	// AC 或者 规约
                    GrammerRule rule;

                    rule = ((ConvertionAction)action).Rule;
                    int length = rule.Right.Count;
                    VertexNonterminal vn = new VertexNonterminal(rule.Left.Name);
                    vn.Children = new List<Vertex>();
                    while (length > 0)
                    {
                        Vertex child = letterStack.Pop();
                        child.Father = vn;
                        vn.Children.Add(child);
                        statusStack.Pop();
                        length--;
                    }
                    vn.Children.Reverse();
                    if (((ConvertionAction)action).Acceptable)
                        return vn;
                    else
                        inputStack.Push(vn);
                }
            }
        }

    }
}
