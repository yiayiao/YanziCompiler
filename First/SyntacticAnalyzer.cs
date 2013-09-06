using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Storage;
using Algorithm.SyntacticAnalyzer;
using Storage.SyntacticAnalyzer;

namespace UserInterface
{
    public partial class SyntacticAnalyzerForm : Form
    {
        private ProductionManager grammer;
        private Analyzer analyzer;
        private int height, width;
        private int processSeqIndex;

        public SyntacticAnalyzerForm()
        {
            InitializeComponent();
        }

        private void linkOpenText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.grammeTextBox.Text = File.OpenText(openFileDialog.FileName).ReadToEnd();
            }
            StartAnalyze(sender, e);
        }

        private void StartAnalyze(object sender, EventArgs e)
        {
            try
            {
                string grammerText = this.grammeTextBox.Text;
                grammerText = grammerText.Replace(" ", "");
                grammer = new ProductionManager(grammerText, null);
                analyzer = new Analyzer(grammer);
                analyzer.Analyze();
            }
            catch (Exception ex)
            {
                MessageBox.Show("分析错误：" + Environment.NewLine + ex.Message, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintBasicResult();
            ShowItemSets();
            ShowActionTable();
        }

        private void initView() //各个listview的初始化
        {
            proListView.Clear();    // 38, 174
            proListView.Columns.Add("ID", 38, HorizontalAlignment.Left);
            proListView.Columns.Add("产生式", 174, HorizontalAlignment.Left);
            nonterminalListView.Clear();
            nonterminalListView.Columns.Add("ID", 37, HorizontalAlignment.Left);
            nonterminalListView.Columns.Add("非终结符", 154, HorizontalAlignment.Left);
            terminalListView.Clear();
            terminalListView.Columns.Add("ID", 37, HorizontalAlignment.Left);
            terminalListView.Columns.Add("终结符", 154, HorizontalAlignment.Left);
            FirstListView.Clear();
            FirstListView.Columns.Add("ID", 37, HorizontalAlignment.Left);
            FirstListView.Columns.Add("First集", 154, HorizontalAlignment.Left);
        }

        private void PrintBasicResult()
        {
            initView();
            for (int i = 0; i < grammer.GrammerRuleSet.Count; i++)
            {
                ListViewItem item = proListView.Items.Add((i + 1).ToString());
                GrammerRule grammerRule = grammer.GrammerRuleSet[i];
                item.SubItems.Add(grammerRule.ToString());
            }

            for (int i = 0; i < grammer.VertexNonterminalSet.Count; i++)
            {
                ListViewItem item = nonterminalListView.Items.Add((i + 1).ToString());
                item.SubItems.Add(grammer.VertexNonterminalSet[i].ToString());
            }

            for (int i = 0; i < grammer.VertexTerminatorSet.Count; i++)
            {
                ListViewItem item = this.terminalListView.Items.Add((i + 1).ToString());
                item.SubItems.Add(grammer.VertexTerminatorSet[i].ToString());
            }

            foreach (var first in grammer.First)
            {
                ListViewItem item = this.FirstListView.Items.Add(String.Format("{0}", first.Key));
                string str = "{ ";
                foreach (var v in first.Value)
                {
                    str += v.ToString() + ",";
                }
                str = str.Remove(str.Length - 1) + " }";
                item.SubItems.Add(str);
            }
        }

        private void ShowItemSets()
        {
            this.ItemSetListView.Clear();
            this.ItemSetListView.Columns.Add("ID", 40, HorizontalAlignment.Left);
            this.ItemSetListView.Columns.Add("项目集", 224, HorizontalAlignment.Left);

            foreach (var itemSet in this.analyzer.ItemFamily.AllItemSet)
            {
                ListViewItem item = this.ItemSetListView.Items.Add("I" + itemSet.Index + ":");
                foreach (var p in itemSet.Items)
                {
                    string itemSetString = "";
                    if (p.IsCore)
                        itemSetString += "[Core]";
                    itemSetString += p.ToString();
                    item.SubItems.Add(itemSetString);

                    item = this.ItemSetListView.Items.Add("");
                }
            }
        }

        private void ShowActionTable()
        {
            ActionTableListView.Columns.Clear();
            ActionTableListView.Columns.Add("Status");
            ActionTableListView.Items.Clear();

            Dictionary<Vertex, int> position = new Dictionary<Vertex, int>();
            int cot = 1;
            foreach (var vn in grammer.VertexNonterminalSet)
            {
                ActionTableListView.Columns.Add(vn.ToString());
                position.Add(vn, cot++);
            }
            foreach (var vt in grammer.VertexTerminatorSet)
            {
                ActionTableListView.Columns.Add(vt.ToString());
                position.Add(vt, cot++);
            }

            foreach (var itemSet in this.analyzer.ItemFamily.AllItemSet)
            {
                ListViewItem item = new ListViewItem();
                for (int i = 0; i < this.ActionTableListView.Columns.Count; i++)
                {
                    item.SubItems.Add("");
                }

                foreach (var action in itemSet.ActionTable)
                {
                    item.SubItems[position[action.Key]].Text = action.Value.ToString();
                }

                item.SubItems[0].Text = itemSet.ToString();
                ActionTableListView.Items.Add(item);
            }

            foreach (ColumnHeader c in ActionTableListView.Columns)
            {
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void SyntacticAnalyzerForm_Load(object sender, EventArgs e)
        {
            height = this.Height;
            width = this.Width;
        }

        private void SyntacticAnalyzerForm_Leave(object sender, EventArgs e)
        {
        }

        private void KeyButton1_Click(object sender, EventArgs e)
        {
            int record_mouse = grammeTextBox.SelectionStart;
            string content = grammeTextBox.Text.Substring(record_mouse);
            grammeTextBox.Text = grammeTextBox.Text.Substring(0, record_mouse);
            grammeTextBox.Text += "->" + content;
            grammeTextBox.Select(record_mouse + 2, record_mouse + 2);
        }

        private void KeyButton2_Click(object sender, EventArgs e)
        {
            int record_mouse = grammeTextBox.SelectionStart;
            string content = grammeTextBox.Text.Substring(record_mouse);
            grammeTextBox.Text = grammeTextBox.Text.Substring(0, record_mouse);
            grammeTextBox.Text += "ε" + content;
            grammeTextBox.Select(record_mouse + 1, record_mouse + 1);

        }

        private void SyntacticAnalyzerForm_Resize(object sender, EventArgs e)
        {
            this.startAnalysis.Location = new Point((this.Width - 100) / 2, this.Height - 120);
            this.proListView.Width += this.Width - width;
            this.proListView.Height += this.Height - height;
            this.nonterminalListView.Height += this.Height - height;
            this.nonterminalListView.Location = new Point(this.nonterminalListView.Location.X + this.Width - width, this.nonterminalListView.Location.Y);
            this.terminalListView.Height += this.Height - height;
            this.terminalListView.Location = new Point(this.terminalListView.Location.X + this.Width - width, this.terminalListView.Location.Y);
            this.FirstListView.Height += this.Height - height;
            this.FirstListView.Location = new Point(this.FirstListView.Location.X + this.Width - width, this.FirstListView.Location.Y);
            this.ActionTableListView.Height += this.Height - height;
            this.ItemSetListView.Height += this.Height - height;
            this.ActionTableListView.Width += this.Width - width;
            height = this.Height;
            width = this.Width;
        }

        private void combineSameCore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.analyzer.CombineBySameCore();
            ShowItemSets();
            ShowActionTable();
        }

        public static String JoinToStringBy<T>(IEnumerable<T> list, string spilter = "")
            where T : class
        {
            string ret = "";
            foreach (T item in list)
            {
                ret += item.ToString() + spilter;
            }
            ret = ret.Substring(0, ret.Length - spilter.Length);
            return ret;
        }

        public void OnAnalysisProcess(Stack<ItemSet> statusStack, Stack<Vertex> letterStack, Stack<Vertex> inputStack, Algorithm.SyntacticAnalyzer.Action action)
        {
            ListViewItem item = new ListViewItem(this.processSeqIndex.ToString());
            item.SubItems.Add(JoinToStringBy(statusStack.Reverse().ToList(), "|"));
            item.SubItems.Add(JoinToStringBy(letterStack.Reverse().ToList(), ""));
            item.SubItems.Add(inputStack.Peek().ToString());
            item.SubItems.Add(inputStack.Count.ToString());
            item.SubItems.Add(action.ToString());
            listViewAnalysisProcess.Items.Add(item);
            processSeqIndex++;
        }

        private void btnStartAnalysis_Click(object sender, EventArgs e)
        {
            if (analyzer == null)
            {
                MessageBox.Show("请先分析文法！", "无法测试", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listViewAnalysisProcess.Items.Clear();
            analyzer.CombineBySameCore();
            analyzer.OnAnalysisProcess = OnAnalysisProcess;

            VertexNonterminal grammerTree = null;
            try
            {
                grammerTree = analyzer.Test(txtTest.Text);
            }
            catch (TestFailedException ex)
            {
                MessageBox.Show(ex.Message, "测试失败", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
        }

    }
}
