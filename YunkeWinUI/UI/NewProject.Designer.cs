namespace CloudMaps
{
    partial class NewProjectForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.btnNewProjectSure = new System.Windows.Forms.Button();
            this.btnNewProjectCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "位置";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(91, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(151, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Location = new System.Drawing.Point(272, 56);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(50, 24);
            this.btnFolderBrowser.TabIndex = 4;
            this.btnFolderBrowser.Text = "浏览";
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // btnNewProjectSure
            // 
            this.btnNewProjectSure.Location = new System.Drawing.Point(92, 99);
            this.btnNewProjectSure.Name = "btnNewProjectSure";
            this.btnNewProjectSure.Size = new System.Drawing.Size(50, 24);
            this.btnNewProjectSure.TabIndex = 5;
            this.btnNewProjectSure.Text = "确定";
            this.btnNewProjectSure.UseVisualStyleBackColor = true;
            this.btnNewProjectSure.Click += new System.EventHandler(this.btnNewProjectSure_Click);
            // 
            // btnNewProjectCancel
            // 
            this.btnNewProjectCancel.Location = new System.Drawing.Point(171, 99);
            this.btnNewProjectCancel.Name = "btnNewProjectCancel";
            this.btnNewProjectCancel.Size = new System.Drawing.Size(50, 24);
            this.btnNewProjectCancel.TabIndex = 6;
            this.btnNewProjectCancel.Text = "取消";
            this.btnNewProjectCancel.UseVisualStyleBackColor = true;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 137);
            this.Controls.Add(this.btnNewProjectCancel);
            this.Controls.Add(this.btnNewProjectSure);
            this.Controls.Add(this.btnFolderBrowser);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.Button btnNewProjectSure;
        private System.Windows.Forms.Button btnNewProjectCancel;
    }
}