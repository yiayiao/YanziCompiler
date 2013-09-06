namespace UserInterface
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResaveFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompilerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LexicalAnalyzerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartCompileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeTextBox = new System.Windows.Forms.RichTextBox();
            this.RusultTabControl = new System.Windows.Forms.TabControl();
            this.LexicalResult = new System.Windows.Forms.TabPage();
            this.LexicaRresultView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.String = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuadruplesResult = new System.Windows.Forms.TabPage();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.SyntacticAnalyzerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.RusultTabControl.SuspendLayout();
            this.LexicalResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileItem,
            this.CompilerItem,
            this.FormatItem,
            this.HelpItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileItem
            // 
            this.FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileItem,
            this.OpenFileItem,
            this.SaveFileItem,
            this.ResaveFileItem,
            this.toolStripSeparator1,
            this.ExitItem});
            this.FileItem.Name = "FileItem";
            this.FileItem.Size = new System.Drawing.Size(57, 20);
            this.FileItem.Text = "文件(&F)";
            // 
            // NewFileItem
            // 
            this.NewFileItem.Name = "NewFileItem";
            this.NewFileItem.Size = new System.Drawing.Size(126, 22);
            this.NewFileItem.Text = "新建(&N)";
            this.NewFileItem.Click += new System.EventHandler(this.NewFileItem_Click);
            // 
            // OpenFileItem
            // 
            this.OpenFileItem.Name = "OpenFileItem";
            this.OpenFileItem.Size = new System.Drawing.Size(126, 22);
            this.OpenFileItem.Text = "打开(&O)";
            this.OpenFileItem.Click += new System.EventHandler(this.OpenFileItem_Click);
            // 
            // SaveFileItem
            // 
            this.SaveFileItem.Name = "SaveFileItem";
            this.SaveFileItem.Size = new System.Drawing.Size(126, 22);
            this.SaveFileItem.Text = "保存(&S)";
            this.SaveFileItem.Click += new System.EventHandler(this.SaveFileItem_Click);
            // 
            // ResaveFileItem
            // 
            this.ResaveFileItem.Name = "ResaveFileItem";
            this.ResaveFileItem.Size = new System.Drawing.Size(126, 22);
            this.ResaveFileItem.Text = "另存为(&A)";
            this.ResaveFileItem.Click += new System.EventHandler(this.ResaveFileItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(126, 22);
            this.ExitItem.Text = "退出(&E)";
            // 
            // CompilerItem
            // 
            this.CompilerItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LexicalAnalyzerItem,
            this.SyntacticAnalyzerItem,
            this.StartCompileItem,
            this.RunItem});
            this.CompilerItem.Name = "CompilerItem";
            this.CompilerItem.Size = new System.Drawing.Size(58, 20);
            this.CompilerItem.Text = "编译(&E)";
            // 
            // LexicalAnalyzerItem
            // 
            this.LexicalAnalyzerItem.Name = "LexicalAnalyzerItem";
            this.LexicalAnalyzerItem.Size = new System.Drawing.Size(152, 22);
            this.LexicalAnalyzerItem.Text = "词法分析(&A)";
            this.LexicalAnalyzerItem.Click += new System.EventHandler(this.LexicalAnalyzerItem_Click);
            // 
            // StartCompileItem
            // 
            this.StartCompileItem.Name = "StartCompileItem";
            this.StartCompileItem.Size = new System.Drawing.Size(152, 22);
            this.StartCompileItem.Text = "开始编译(&C)";
            // 
            // RunItem
            // 
            this.RunItem.Name = "RunItem";
            this.RunItem.Size = new System.Drawing.Size(152, 22);
            this.RunItem.Text = "运行(&R)";
            // 
            // FormatItem
            // 
            this.FormatItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontItem,
            this.SettleItem});
            this.FormatItem.Name = "FormatItem";
            this.FormatItem.Size = new System.Drawing.Size(61, 20);
            this.FormatItem.Text = "格式(&O)";
            // 
            // FontItem
            // 
            this.FontItem.Name = "FontItem";
            this.FontItem.Size = new System.Drawing.Size(138, 22);
            this.FontItem.Text = "字体(&F)";
            // 
            // SettleItem
            // 
            this.SettleItem.Name = "SettleItem";
            this.SettleItem.Size = new System.Drawing.Size(138, 22);
            this.SettleItem.Text = "整理格式(&B)";
            // 
            // HelpItem
            // 
            this.HelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutItem});
            this.HelpItem.Name = "HelpItem";
            this.HelpItem.Size = new System.Drawing.Size(60, 20);
            this.HelpItem.Text = "帮助(&H)";
            // 
            // AboutItem
            // 
            this.AboutItem.Name = "AboutItem";
            this.AboutItem.Size = new System.Drawing.Size(114, 22);
            this.AboutItem.Text = "关于(&A)";
            this.AboutItem.Click += new System.EventHandler(this.AboutItem_Click);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(0, 27);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(434, 400);
            this.CodeTextBox.TabIndex = 1;
            this.CodeTextBox.Text = "";
            this.CodeTextBox.TextChanged += new System.EventHandler(this.CodeTextBox_TextChanged);
            // 
            // RusultTabControl
            // 
            this.RusultTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RusultTabControl.Controls.Add(this.LexicalResult);
            this.RusultTabControl.Controls.Add(this.QuadruplesResult);
            this.RusultTabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.RusultTabControl.Location = new System.Drawing.Point(440, 27);
            this.RusultTabControl.Name = "RusultTabControl";
            this.RusultTabControl.SelectedIndex = 0;
            this.RusultTabControl.Size = new System.Drawing.Size(344, 400);
            this.RusultTabControl.TabIndex = 2;
            // 
            // LexicalResult
            // 
            this.LexicalResult.Controls.Add(this.LexicaRresultView);
            this.LexicalResult.Location = new System.Drawing.Point(4, 22);
            this.LexicalResult.Name = "LexicalResult";
            this.LexicalResult.Padding = new System.Windows.Forms.Padding(3);
            this.LexicalResult.Size = new System.Drawing.Size(336, 374);
            this.LexicalResult.TabIndex = 0;
            this.LexicalResult.Text = "二元组";
            this.LexicalResult.UseVisualStyleBackColor = true;
            // 
            // LexicaRresultView
            // 
            this.LexicaRresultView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.String,
            this.Type,
            this.Line,
            this.Column});
            this.LexicaRresultView.FullRowSelect = true;
            this.LexicaRresultView.GridLines = true;
            this.LexicaRresultView.Location = new System.Drawing.Point(0, 0);
            this.LexicaRresultView.Name = "LexicaRresultView";
            this.LexicaRresultView.Size = new System.Drawing.Size(340, 374);
            this.LexicaRresultView.TabIndex = 3;
            this.LexicaRresultView.UseCompatibleStateImageBehavior = false;
            this.LexicaRresultView.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Tag = "Id";
            this.Id.Text = "Id";
            this.Id.Width = 29;
            // 
            // String
            // 
            this.String.Tag = "String";
            this.String.Text = "String";
            this.String.Width = 138;
            // 
            // Type
            // 
            this.Type.Tag = "Type";
            this.Type.Text = "Type";
            this.Type.Width = 78;
            // 
            // Line
            // 
            this.Line.Tag = "Line";
            this.Line.Text = "Line";
            this.Line.Width = 46;
            // 
            // Column
            // 
            this.Column.Tag = "Column";
            this.Column.Text = "Column";
            this.Column.Width = 57;
            // 
            // QuadruplesResult
            // 
            this.QuadruplesResult.Location = new System.Drawing.Point(4, 22);
            this.QuadruplesResult.Name = "QuadruplesResult";
            this.QuadruplesResult.Padding = new System.Windows.Forms.Padding(3);
            this.QuadruplesResult.Size = new System.Drawing.Size(336, 374);
            this.QuadruplesResult.TabIndex = 1;
            this.QuadruplesResult.Text = "四元组";
            this.QuadruplesResult.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OutputTextBox.Location = new System.Drawing.Point(0, 433);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputTextBox.Size = new System.Drawing.Size(784, 128);
            this.OutputTextBox.TabIndex = 3;
            // 
            // SyntacticAnalyzerItem
            // 
            this.SyntacticAnalyzerItem.Name = "SyntacticAnalyzerItem";
            this.SyntacticAnalyzerItem.Size = new System.Drawing.Size(152, 22);
            this.SyntacticAnalyzerItem.Text = "语法分析(&S)";
            this.SyntacticAnalyzerItem.Click += new System.EventHandler(this.SyntacticAnalyzerItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.RusultTabControl);
            this.Controls.Add(this.CodeTextBox);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Text = "燕子编译器";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Leave += new System.EventHandler(this.MainForm_Leave);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.RusultTabControl.ResumeLayout(false);
            this.LexicalResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileItem;
        private System.Windows.Forms.ToolStripMenuItem CompilerItem;
        private System.Windows.Forms.ToolStripMenuItem FormatItem;
        private System.Windows.Forms.ToolStripMenuItem HelpItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileItem;
        private System.Windows.Forms.ToolStripMenuItem FontItem;
        private System.Windows.Forms.ToolStripMenuItem SettleItem;
        private System.Windows.Forms.ToolStripMenuItem ResaveFileItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem StartCompileItem;
        private System.Windows.Forms.ToolStripMenuItem RunItem;
        private System.Windows.Forms.ToolStripMenuItem AboutItem;
        private System.Windows.Forms.RichTextBox CodeTextBox;
        private System.Windows.Forms.TabControl RusultTabControl;
        private System.Windows.Forms.TabPage LexicalResult;
        private System.Windows.Forms.TabPage QuadruplesResult;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.ToolStripMenuItem LexicalAnalyzerItem;
        private System.Windows.Forms.ListView LexicaRresultView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader String;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Line;
        private System.Windows.Forms.ColumnHeader Column;
        private System.Windows.Forms.ToolStripMenuItem SyntacticAnalyzerItem;
    }
}

