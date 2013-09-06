namespace UserInterface
{
    partial class SyntacticAnalyzerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyntacticAnalyzerForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.KeyButton2 = new System.Windows.Forms.Button();
            this.KeyButton1 = new System.Windows.Forms.Button();
            this.startAnalysis = new System.Windows.Forms.Button();
            this.linkOpenText = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.grammeTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FirstListView = new System.Windows.Forms.ListView();
            this.firId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.terminalListView = new System.Windows.Forms.ListView();
            this.terId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.terminal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nonterminalListView = new System.Windows.Forms.ListView();
            this.nonId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nonterminal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proListView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Production = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ActionTableListView = new System.Windows.Forms.ListView();
            this.ItemSetListView = new System.Windows.Forms.ListView();
            this.ItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.combineSameCore = new System.Windows.Forms.LinkLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.btnStartAnalysis = new System.Windows.Forms.Button();
            this.listViewAnalysisProcess = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 489);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.KeyButton2);
            this.tabPage1.Controls.Add(this.KeyButton1);
            this.tabPage1.Controls.Add(this.startAnalysis);
            this.tabPage1.Controls.Add(this.linkOpenText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.grammeTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文法输入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // KeyButton2
            // 
            this.KeyButton2.Location = new System.Drawing.Point(206, 20);
            this.KeyButton2.Name = "KeyButton2";
            this.KeyButton2.Size = new System.Drawing.Size(23, 23);
            this.KeyButton2.TabIndex = 5;
            this.KeyButton2.Text = "ε";
            this.KeyButton2.UseVisualStyleBackColor = true;
            this.KeyButton2.Click += new System.EventHandler(this.KeyButton2_Click);
            // 
            // KeyButton1
            // 
            this.KeyButton1.Location = new System.Drawing.Point(168, 20);
            this.KeyButton1.Name = "KeyButton1";
            this.KeyButton1.Size = new System.Drawing.Size(23, 23);
            this.KeyButton1.TabIndex = 4;
            this.KeyButton1.Text = "→";
            this.KeyButton1.UseVisualStyleBackColor = true;
            this.KeyButton1.Click += new System.EventHandler(this.KeyButton1_Click);
            // 
            // startAnalysis
            // 
            this.startAnalysis.Location = new System.Drawing.Point(366, 407);
            this.startAnalysis.Name = "startAnalysis";
            this.startAnalysis.Size = new System.Drawing.Size(100, 42);
            this.startAnalysis.TabIndex = 3;
            this.startAnalysis.Text = "分析文法";
            this.startAnalysis.UseVisualStyleBackColor = true;
            this.startAnalysis.Click += new System.EventHandler(this.StartAnalyze);
            // 
            // linkOpenText
            // 
            this.linkOpenText.AutoSize = true;
            this.linkOpenText.Location = new System.Drawing.Point(70, 25);
            this.linkOpenText.Name = "linkOpenText";
            this.linkOpenText.Size = new System.Drawing.Size(77, 12);
            this.linkOpenText.TabIndex = 2;
            this.linkOpenText.TabStop = true;
            this.linkOpenText.Text = "从文件中读入";
            this.linkOpenText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenText_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文法正文：";
            // 
            // grammeTextBox
            // 
            this.grammeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grammeTextBox.Location = new System.Drawing.Point(15, 59);
            this.grammeTextBox.Multiline = true;
            this.grammeTextBox.Name = "grammeTextBox";
            this.grammeTextBox.Size = new System.Drawing.Size(842, 336);
            this.grammeTextBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FirstListView);
            this.tabPage2.Controls.Add(this.terminalListView);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.nonterminalListView);
            this.tabPage2.Controls.Add(this.proListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " 基本信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FirstListView
            // 
            this.FirstListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.firId,
            this.firstSet});
            this.FirstListView.FullRowSelect = true;
            this.FirstListView.GridLines = true;
            this.FirstListView.Location = new System.Drawing.Point(665, 16);
            this.FirstListView.Name = "FirstListView";
            this.FirstListView.Size = new System.Drawing.Size(195, 407);
            this.FirstListView.TabIndex = 7;
            this.FirstListView.UseCompatibleStateImageBehavior = false;
            this.FirstListView.View = System.Windows.Forms.View.Details;
            // 
            // firId
            // 
            this.firId.Text = "Id";
            this.firId.Width = 37;
            // 
            // firstSet
            // 
            this.firstSet.Text = "First集";
            this.firstSet.Width = 154;
            // 
            // terminalListView
            // 
            this.terminalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.terId,
            this.terminal});
            this.terminalListView.FullRowSelect = true;
            this.terminalListView.GridLines = true;
            this.terminalListView.Location = new System.Drawing.Point(464, 16);
            this.terminalListView.Name = "terminalListView";
            this.terminalListView.Size = new System.Drawing.Size(195, 407);
            this.terminalListView.TabIndex = 6;
            this.terminalListView.UseCompatibleStateImageBehavior = false;
            this.terminalListView.View = System.Windows.Forms.View.Details;
            // 
            // terId
            // 
            this.terId.Text = "Id";
            this.terId.Width = 37;
            // 
            // terminal
            // 
            this.terminal.Text = "终结符";
            this.terminal.Width = 154;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(441, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(0, 0);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 42;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "产生式";
            this.columnHeader4.Width = 154;
            // 
            // nonterminalListView
            // 
            this.nonterminalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nonId,
            this.nonterminal});
            this.nonterminalListView.FullRowSelect = true;
            this.nonterminalListView.GridLines = true;
            this.nonterminalListView.Location = new System.Drawing.Point(263, 16);
            this.nonterminalListView.Name = "nonterminalListView";
            this.nonterminalListView.Size = new System.Drawing.Size(195, 407);
            this.nonterminalListView.TabIndex = 4;
            this.nonterminalListView.UseCompatibleStateImageBehavior = false;
            this.nonterminalListView.View = System.Windows.Forms.View.Details;
            // 
            // nonId
            // 
            this.nonId.Text = "Id";
            this.nonId.Width = 37;
            // 
            // nonterminal
            // 
            this.nonterminal.Text = "非终结符";
            this.nonterminal.Width = 154;
            // 
            // proListView
            // 
            this.proListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Production});
            this.proListView.FullRowSelect = true;
            this.proListView.GridLines = true;
            this.proListView.Location = new System.Drawing.Point(18, 16);
            this.proListView.Name = "proListView";
            this.proListView.Size = new System.Drawing.Size(239, 407);
            this.proListView.TabIndex = 0;
            this.proListView.UseCompatibleStateImageBehavior = false;
            this.proListView.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 38;
            // 
            // Production
            // 
            this.Production.Text = "产生式";
            this.Production.Width = 196;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.combineSameCore);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.ActionTableListView);
            this.tabPage3.Controls.Add(this.ItemSetListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(876, 463);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "项目集";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(539, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "分析表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(76, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目集";
            // 
            // ActionTableListView
            // 
            this.ActionTableListView.FullRowSelect = true;
            this.ActionTableListView.GridLines = true;
            this.ActionTableListView.Location = new System.Drawing.Point(295, 31);
            this.ActionTableListView.Name = "ActionTableListView";
            this.ActionTableListView.Size = new System.Drawing.Size(542, 391);
            this.ActionTableListView.TabIndex = 1;
            this.ActionTableListView.UseCompatibleStateImageBehavior = false;
            this.ActionTableListView.View = System.Windows.Forms.View.Details;
            // 
            // ItemSetListView
            // 
            this.ItemSetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemId,
            this.ItemSet});
            this.ItemSetListView.FullRowSelect = true;
            this.ItemSetListView.Location = new System.Drawing.Point(12, 31);
            this.ItemSetListView.Name = "ItemSetListView";
            this.ItemSetListView.Size = new System.Drawing.Size(269, 392);
            this.ItemSetListView.TabIndex = 0;
            this.ItemSetListView.UseCompatibleStateImageBehavior = false;
            this.ItemSetListView.View = System.Windows.Forms.View.Details;
            // 
            // ItemId
            // 
            this.ItemId.Text = "ID";
            this.ItemId.Width = 40;
            // 
            // ItemSet
            // 
            this.ItemSet.Text = " 项目集";
            this.ItemSet.Width = 224;
            // 
            // combineSameCore
            // 
            this.combineSameCore.AutoSize = true;
            this.combineSameCore.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combineSameCore.Location = new System.Drawing.Point(123, 8);
            this.combineSameCore.Name = "combineSameCore";
            this.combineSameCore.Size = new System.Drawing.Size(89, 20);
            this.combineSameCore.TabIndex = 4;
            this.combineSameCore.TabStop = true;
            this.combineSameCore.Text = "(合并同心集)";
            this.combineSameCore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.combineSameCore_LinkClicked);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listViewAnalysisProcess);
            this.tabPage4.Controls.Add(this.btnStartAnalysis);
            this.tabPage4.Controls.Add(this.txtTest);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(876, 463);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "语法分析";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtTest
            // 
            this.txtTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTest.Location = new System.Drawing.Point(15, 7);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTest.Size = new System.Drawing.Size(746, 56);
            this.txtTest.TabIndex = 8;
            // 
            // btnStartAnalysis
            // 
            this.btnStartAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("btnStartAnalysis.Image")));
            this.btnStartAnalysis.Location = new System.Drawing.Point(787, 19);
            this.btnStartAnalysis.Name = "btnStartAnalysis";
            this.btnStartAnalysis.Size = new System.Drawing.Size(66, 26);
            this.btnStartAnalysis.TabIndex = 9;
            this.btnStartAnalysis.Text = "分析";
            this.btnStartAnalysis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartAnalysis.UseVisualStyleBackColor = true;
            this.btnStartAnalysis.Click += new System.EventHandler(this.btnStartAnalysis_Click);
            // 
            // listViewAnalysisProcess
            // 
            this.listViewAnalysisProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAnalysisProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewAnalysisProcess.FullRowSelect = true;
            this.listViewAnalysisProcess.GridLines = true;
            this.listViewAnalysisProcess.Location = new System.Drawing.Point(17, 71);
            this.listViewAnalysisProcess.Name = "listViewAnalysisProcess";
            this.listViewAnalysisProcess.Size = new System.Drawing.Size(839, 389);
            this.listViewAnalysisProcess.TabIndex = 10;
            this.listViewAnalysisProcess.UseCompatibleStateImageBehavior = false;
            this.listViewAnalysisProcess.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "ID";
            this.columnHeader0.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态栈";
            this.columnHeader2.Width = 333;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "符号栈";
            this.columnHeader1.Width = 239;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "当前符号";
            this.columnHeader5.Width = 61;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "剩余";
            this.columnHeader6.Width = 43;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "动作";
            this.columnHeader7.Width = 103;
            // 
            // SyntacticAnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 489);
            this.Controls.Add(this.tabControl1);
            this.Name = "SyntacticAnalyzerForm";
            this.Text = "燕子编译器-语法分析";
            this.Load += new System.EventHandler(this.SyntacticAnalyzerForm_Load);
            this.Leave += new System.EventHandler(this.SyntacticAnalyzerForm_Leave);
            this.Resize += new System.EventHandler(this.SyntacticAnalyzerForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox grammeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkOpenText;
        private System.Windows.Forms.Button startAnalysis;
        private System.Windows.Forms.Button KeyButton1;
        private System.Windows.Forms.Button KeyButton2;
        private System.Windows.Forms.ListView proListView;
        private System.Windows.Forms.ListView nonterminalListView;
        private System.Windows.Forms.ColumnHeader nonId;
        private System.Windows.Forms.ColumnHeader nonterminal;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Production;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView terminalListView;
        private System.Windows.Forms.ColumnHeader terId;
        private System.Windows.Forms.ColumnHeader terminal;
        private System.Windows.Forms.ListView FirstListView;
        private System.Windows.Forms.ColumnHeader firId;
        private System.Windows.Forms.ColumnHeader firstSet;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView ActionTableListView;
        private System.Windows.Forms.ListView ItemSetListView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader ItemId;
        private System.Windows.Forms.ColumnHeader ItemSet;
        private System.Windows.Forms.LinkLabel combineSameCore;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listViewAnalysisProcess;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnStartAnalysis;
        private System.Windows.Forms.TextBox txtTest;
    }
}