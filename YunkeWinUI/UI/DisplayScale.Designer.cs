namespace CloudMaps
{
    partial class DisplayScaleForm
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
            this.btnDisplayScaleOK = new System.Windows.Forms.Button();
            this.btnDisplayScaleCancle = new System.Windows.Forms.Button();
            this.groupBox_DisplayScale = new System.Windows.Forms.GroupBox();
            this.radioButton_200 = new System.Windows.Forms.RadioButton();
            this.radioButton_150 = new System.Windows.Forms.RadioButton();
            this.radioButton_100 = new System.Windows.Forms.RadioButton();
            this.radioButton_50 = new System.Windows.Forms.RadioButton();
            this.numericUpDown_DisplayScale = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_DisplayScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DisplayScale)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisplayScaleOK
            // 
            this.btnDisplayScaleOK.Location = new System.Drawing.Point(75, 191);
            this.btnDisplayScaleOK.Name = "btnDisplayScaleOK";
            this.btnDisplayScaleOK.Size = new System.Drawing.Size(40, 25);
            this.btnDisplayScaleOK.TabIndex = 1;
            this.btnDisplayScaleOK.Text = "确定";
            this.btnDisplayScaleOK.UseVisualStyleBackColor = true;
            this.btnDisplayScaleOK.Click += new System.EventHandler(this.btnDisplayScaleOK_Click);
            // 
            // btnDisplayScaleCancle
            // 
            this.btnDisplayScaleCancle.Location = new System.Drawing.Point(157, 191);
            this.btnDisplayScaleCancle.Name = "btnDisplayScaleCancle";
            this.btnDisplayScaleCancle.Size = new System.Drawing.Size(40, 25);
            this.btnDisplayScaleCancle.TabIndex = 2;
            this.btnDisplayScaleCancle.Text = "取消";
            this.btnDisplayScaleCancle.UseVisualStyleBackColor = true;
            this.btnDisplayScaleCancle.Click += new System.EventHandler(this.btnDisplayScaleCancle_Click);
            // 
            // groupBox_DisplayScale
            // 
            this.groupBox_DisplayScale.Controls.Add(this.radioButton_200);
            this.groupBox_DisplayScale.Controls.Add(this.radioButton_150);
            this.groupBox_DisplayScale.Controls.Add(this.radioButton_100);
            this.groupBox_DisplayScale.Controls.Add(this.radioButton_50);
            this.groupBox_DisplayScale.Location = new System.Drawing.Point(40, 29);
            this.groupBox_DisplayScale.Name = "groupBox_DisplayScale";
            this.groupBox_DisplayScale.Size = new System.Drawing.Size(203, 115);
            this.groupBox_DisplayScale.TabIndex = 6;
            this.groupBox_DisplayScale.TabStop = false;
            this.groupBox_DisplayScale.Text = "显示比例";
            // 
            // radioButton_200
            // 
            this.radioButton_200.AutoSize = true;
            this.radioButton_200.Location = new System.Drawing.Point(117, 77);
            this.radioButton_200.Name = "radioButton_200";
            this.radioButton_200.Size = new System.Drawing.Size(47, 16);
            this.radioButton_200.TabIndex = 3;
            this.radioButton_200.Text = "200%";
            this.radioButton_200.UseVisualStyleBackColor = true;
            this.radioButton_200.CheckedChanged += new System.EventHandler(this.radioButton_200_CheckedChanged);
            // 
            // radioButton_150
            // 
            this.radioButton_150.AutoSize = true;
            this.radioButton_150.Location = new System.Drawing.Point(6, 77);
            this.radioButton_150.Name = "radioButton_150";
            this.radioButton_150.Size = new System.Drawing.Size(47, 16);
            this.radioButton_150.TabIndex = 2;
            this.radioButton_150.Text = "150%";
            this.radioButton_150.UseVisualStyleBackColor = true;
            this.radioButton_150.CheckedChanged += new System.EventHandler(this.radioButton_150_CheckedChanged);
            // 
            // radioButton_100
            // 
            this.radioButton_100.AutoSize = true;
            this.radioButton_100.Checked = true;
            this.radioButton_100.Location = new System.Drawing.Point(117, 30);
            this.radioButton_100.Name = "radioButton_100";
            this.radioButton_100.Size = new System.Drawing.Size(47, 16);
            this.radioButton_100.TabIndex = 1;
            this.radioButton_100.TabStop = true;
            this.radioButton_100.Text = "100%";
            this.radioButton_100.UseVisualStyleBackColor = true;
            this.radioButton_100.CheckedChanged += new System.EventHandler(this.radioButton_100_CheckedChanged);
            // 
            // radioButton_50
            // 
            this.radioButton_50.AutoSize = true;
            this.radioButton_50.Location = new System.Drawing.Point(6, 30);
            this.radioButton_50.Name = "radioButton_50";
            this.radioButton_50.Size = new System.Drawing.Size(41, 16);
            this.radioButton_50.TabIndex = 0;
            this.radioButton_50.Text = "50%";
            this.radioButton_50.UseVisualStyleBackColor = true;
            this.radioButton_50.CheckedChanged += new System.EventHandler(this.radioButton_50_CheckedChanged);
            // 
            // numericUpDown_DisplayScale
            // 
            this.numericUpDown_DisplayScale.Location = new System.Drawing.Point(140, 150);
            this.numericUpDown_DisplayScale.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDown_DisplayScale.Name = "numericUpDown_DisplayScale";
            this.numericUpDown_DisplayScale.Size = new System.Drawing.Size(76, 21);
            this.numericUpDown_DisplayScale.TabIndex = 7;
            this.numericUpDown_DisplayScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_DisplayScale.ValueChanged += new System.EventHandler(this.numericUpDown_DisplayScale_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "百分比";
            // 
            // DisplayScaleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(280, 229);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_DisplayScale);
            this.Controls.Add(this.groupBox_DisplayScale);
            this.Controls.Add(this.btnDisplayScaleCancle);
            this.Controls.Add(this.btnDisplayScaleOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayScaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "显示比例";
            this.groupBox_DisplayScale.ResumeLayout(false);
            this.groupBox_DisplayScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DisplayScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisplayScaleOK;
        private System.Windows.Forms.Button btnDisplayScaleCancle;
        private System.Windows.Forms.GroupBox groupBox_DisplayScale;
        private System.Windows.Forms.RadioButton radioButton_200;
        private System.Windows.Forms.RadioButton radioButton_150;
        private System.Windows.Forms.RadioButton radioButton_100;
        private System.Windows.Forms.RadioButton radioButton_50;
        protected System.Windows.Forms.NumericUpDown numericUpDown_DisplayScale;
        private System.Windows.Forms.Label label2;
    }
}