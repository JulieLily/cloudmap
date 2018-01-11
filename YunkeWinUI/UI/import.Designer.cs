namespace CloudMaps
{
    partial class importForm
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
            this.btn_SelectFinish = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.selectedAllRelation = new System.Windows.Forms.CheckBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.checkedListBox_Relation = new System.Windows.Forms.CheckedListBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.selectedAllModules = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.checkedListBox_Module = new System.Windows.Forms.CheckedListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SelectFinish
            // 
            this.btn_SelectFinish.Location = new System.Drawing.Point(139, 19);
            this.btn_SelectFinish.Name = "btn_SelectFinish";
            this.btn_SelectFinish.Size = new System.Drawing.Size(50, 24);
            this.btn_SelectFinish.TabIndex = 8;
            this.btn_SelectFinish.Text = "导入";
            this.btn_SelectFinish.UseVisualStyleBackColor = true;
            this.btn_SelectFinish.Click += new System.EventHandler(this.btn_SelectFinish_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 361);
            this.panel1.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(222, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(222, 315);
            this.panel5.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.selectedAllRelation);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 46);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(222, 269);
            this.panel10.TabIndex = 2;
            // 
            // selectedAllRelation
            // 
            this.selectedAllRelation.AutoSize = true;
            this.selectedAllRelation.Location = new System.Drawing.Point(34, 9);
            this.selectedAllRelation.Name = "selectedAllRelation";
            this.selectedAllRelation.Size = new System.Drawing.Size(48, 16);
            this.selectedAllRelation.TabIndex = 2;
            this.selectedAllRelation.Text = "全选";
            this.selectedAllRelation.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.checkedListBox_Relation);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 28);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(222, 241);
            this.panel11.TabIndex = 0;
            // 
            // checkedListBox_Relation
            // 
            this.checkedListBox_Relation.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkedListBox_Relation.FormattingEnabled = true;
            this.checkedListBox_Relation.Location = new System.Drawing.Point(34, 13);
            this.checkedListBox_Relation.Name = "checkedListBox_Relation";
            this.checkedListBox_Relation.Size = new System.Drawing.Size(143, 212);
            this.checkedListBox_Relation.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(222, 46);
            this.panel9.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "选择关系";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 315);
            this.panel4.TabIndex = 1;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.selectedAllModules);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 46);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(222, 269);
            this.panel7.TabIndex = 1;
            // 
            // selectedAllModules
            // 
            this.selectedAllModules.AutoSize = true;
            this.selectedAllModules.Location = new System.Drawing.Point(46, 9);
            this.selectedAllModules.Name = "selectedAllModules";
            this.selectedAllModules.Size = new System.Drawing.Size(48, 16);
            this.selectedAllModules.TabIndex = 1;
            this.selectedAllModules.Text = "全选";
            this.selectedAllModules.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.checkedListBox_Module);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 28);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(222, 241);
            this.panel8.TabIndex = 0;
            // 
            // checkedListBox_Module
            // 
            this.checkedListBox_Module.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkedListBox_Module.FormattingEnabled = true;
            this.checkedListBox_Module.Location = new System.Drawing.Point(46, 13);
            this.checkedListBox_Module.Name = "checkedListBox_Module";
            this.checkedListBox_Module.Size = new System.Drawing.Size(143, 212);
            this.checkedListBox_Module.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(222, 46);
            this.panel6.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(43, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择系统";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFolderBrowser);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(444, 46);
            this.panel3.TabIndex = 0;
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Location = new System.Drawing.Point(369, 13);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(50, 24);
            this.btnFolderBrowser.TabIndex = 5;
            this.btnFolderBrowser.Text = "浏览";
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择项目";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_SelectFinish);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 61);
            this.panel2.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // importForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 422);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "importForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入系统";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectFinish;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.CheckBox selectedAllRelation;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.CheckedListBox checkedListBox_Relation;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox selectedAllModules;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckedListBox checkedListBox_Module;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}