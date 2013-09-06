using Storage.LexicalAnalyzer;
using Algorithm.LexicalAnalyzer;
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

namespace UserInterface
{
    public partial class MainForm : Form
    {
        private string filename;
        private List<Token> tokenList = new List<Token>();
        private List<string> errorList = new List<string>();
        private bool isSysFormOpen;

        public MainForm()
        {
            InitializeComponent();
            isSysFormOpen = false;
            this.CodeTextBox.Font = new Font("黑体", 14.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitialViewers();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            CodeTextBox.Width = this.Width - RusultTabControl.Width - 22;
            OutputTextBox.Height = this.Height - MenuStrip.Height - CodeTextBox.Height - 46;
        }

        #region 文件的基本操作，打开，保存，另存为
        private void NewFileItem_Click(object sender, EventArgs e)
        {
            //先询问用户是否保存当前文件
            CodeTextBox.Text = "";
        }

        private void OpenFileItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "text(*.txt)|*.txt|(*.yz)|*.yz";
            openFile.ShowDialog();
            filename = openFile.FileName;
            try
            {
                CodeTextBox.Text = File.ReadAllText(filename, System.Text.Encoding.Default).Replace("\r", "");
            }
            catch { }
            CodeTextBox.Select(0, 0);
        }

        private void save(string filename, string content)
        {
            if (filename == null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "text(*.txt)|*.txt|(*.yz)|*.yz";
                saveFile.ShowDialog();
                filename = saveFile.FileName;
            }
            try
            {
                File.WriteAllText(filename, content, System.Text.Encoding.Default);
            }
            catch { }
        }

        private void SaveFileItem_Click(object sender, EventArgs e)
        {
            string content = CodeTextBox.Text;
            content = content.Replace("\r", "").Replace("\n", "\r\n");
            save(filename, content);
        }

        private void ResaveFileItem_Click(object sender, EventArgs e)
        {
            string content = CodeTextBox.Text;
            content = content.Replace("\r", "").Replace("\n", "\r\n");
            save(null, content);
        }
        #endregion

        private void ColorWord()
        {
            CodeTextBox.Select(0, this.CodeTextBox.Text.Length);
            CodeTextBox.SelectionColor = Color.Black;
            foreach (Token token in tokenList)
            {
                switch (token.Type)
                {
                    case WordType.Keyword:
                        CodeTextBox.Select(token.Index, token.Content.Length);
                        CodeTextBox.SelectionColor = Color.Blue;
                        break;
                    case WordType.CharConstant:
                        CodeTextBox.Select(token.Index, token.Content.Length);
                        CodeTextBox.SelectionColor = Color.Brown;
                        break;
                    case WordType.StringConstant:
                        CodeTextBox.Select(token.Index, token.Content.Length);
                        CodeTextBox.SelectionColor = Color.Green;
                        break;
                    case WordType.Comment:
                        CodeTextBox.Select(token.Index, token.Content.Length);
                        CodeTextBox.SelectionColor = Color.YellowGreen;
                        break;
                    case WordType.Decimal:
                    case WordType.Octonary:
                    case WordType.Hexadecimal:
                    case WordType.FloatConstant:
                        CodeTextBox.Select(token.Index, token.Content.Length);
                        CodeTextBox.SelectionColor = Color.Purple;
                        break;
                }
            }
        }

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            //CodeTextBox.SelectionStart可以得到光标的位置，使得仅处理新输入的字符
        }

        private void PrintResult(List<Token> tokenList, List<string> errorList)
        {
            InitialViewers();
            foreach (Token t in tokenList)
            {
                ListViewItem item = LexicaRresultView.Items.Add(t.Id.ToString());
                item.SubItems.Add(t.Content);
                var tmp = t.Type.ToString();
                if (t.Type == WordType.Identifier || t.Type == WordType.Keyword)
                {
                    tmp += string.Format(" ({0})", t.Value);
                }
                item.SubItems.Add(tmp);
                item.SubItems.Add(t.Row.ToString());
                item.SubItems.Add(t.Column.ToString());
            }

            foreach (string s in errorList)
            {
                OutputTextBox.Text += s + "\r\n";
            }
        }

        private void InitialViewers()
        {
            LexicaRresultView.Clear();
            LexicaRresultView.Columns.Add("Id", 36, HorizontalAlignment.Center);
            LexicaRresultView.Columns.Add("String", 186, HorizontalAlignment.Center);
            LexicaRresultView.Columns.Add("Type", 110, HorizontalAlignment.Center);
            LexicaRresultView.Columns.Add("Line", 48, HorizontalAlignment.Center);
            LexicaRresultView.Columns.Add("Column", 48, HorizontalAlignment.Center);
            OutputTextBox.Clear();
        }

        private void LexicalAnalyzerItem_Click(object sender, EventArgs e)
        {
            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer(this.CodeTextBox.Text);
            lexicalAnalyzer.Analyses(out tokenList, out errorList);
            int record_mouse = CodeTextBox.SelectionStart;
            ColorWord();
            CodeTextBox.Select(record_mouse, record_mouse);
            PrintResult(tokenList, errorList);
        }

        private void SyntacticAnalyzerItem_Click(object sender, EventArgs e)
        {
            Form systacticForm = new SyntacticAnalyzerForm();
            systacticForm.ShowDialog();
            
        }


        private void AboutItem_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory.Replace('\\', '/') + "/About.txt";
            try
            {
                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                {
                    CodeTextBox.Text = "燕子编辑器";
                }
                else
                {
                    CodeTextBox.Text = File.ReadAllText(path, System.Text.Encoding.Default).Replace("\r", "");
                }
            }
            catch
            { }
            CodeTextBox.Select(0, 0);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //注册快捷键
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.A);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Shift, Keys.S);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Shift, Keys.C);
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.Shift, Keys.R);
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
            HotKey.UnregisterHotKey(Handle, 103);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            if (m.Msg == WM_HOTKEY)
            {

                switch (m.WParam.ToInt32())
                {
                    case 100:

                        break;
                    case 101:    //shift+S
                        if (!isSysFormOpen)
                        {
                            isSysFormOpen = true;
                            Form systacticForm = new SyntacticAnalyzerForm();
                            systacticForm.ShowDialog();
                            isSysFormOpen = false;
                        }
                        break;
                    case 102:
                        break;
                }

            }
            base.WndProc(ref m);
        }
    }
}
