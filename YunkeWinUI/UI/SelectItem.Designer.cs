namespace CloudMaps
{
    partial class GenerateMapForm
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
            this.checkedListBox_Module = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox_Relation = new System.Windows.Forms.CheckedListBox();
            this.btn_SelectFinish = new System.Windows.Forms.Button();
            this.selectedAllModules = new System.Windows.Forms.CheckBox();
            this.selectedAllRelation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkedListBox_Module
            // 
            this.checkedListBox_Module.FormattingEnabled = true;
            this.checkedListBox_Module.Location = new System.Drawing.Point(49, 104);
            this.checkedListBox_Module.Name = "checkedListBox_Module";
            this.checkedListBox_Module.Size = new System.Drawing.Size(146, 228);
            this.checkedListBox_Module.TabIndex = 2;
            this.checkedListBox_Module.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_Module_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择系统";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(280, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择关系";
            // 
            // checkedListBox_Relation
            // 
            this.checkedListBox_Relation.FormattingEnabled = true;
            this.checkedListBox_Relation.Location = new System.Drawing.Point(284, 104);
            this.checkedListBox_Relation.Name = "checkedListBox_Relation";
            this.checkedListBox_Relation.Size = new System.Drawing.Size(152, 228);
            this.checkedListBox_Relation.TabIndex = 5;
            // 
            // btn_SelectFinish
            // 
            this.btn_SelectFinish.Location = new System.Drawing.Point(197, 366);
            this.btn_SelectFinish.Name = "btn_SelectFinish";
            this.btn_SelectFinish.Size = new System.Drawing.Size(80, 32);
            this.btn_SelectFinish.TabIndex = 8;
            this.btn_SelectFinish.Text = "完成";
            this.btn_SelectFinish.UseVisualStyleBackColor = true;
            this.btn_SelectFinish.Click += new System.EventHandler(this.btn_SelectFinish_Click);
            // 
            // selectedAllModules
            // 
            this.selectedAllModules.AutoSize = true;
            this.selectedAllModules.Location = new System.Drawing.Point(52, 84);
            this.selectedAllModules.Name = "selectedAllModules";
            this.selectedAllModules.Size = new System.Drawing.Size(48, 16);
            this.selectedAllModules.TabIndex = 12;
            this.selectedAllModules.Text = "全选";
            this.selectedAllModules.UseVisualStyleBackColor = true;
            this.selectedAllModules.CheckedChanged += new System.EventHandler(this.selectedAll_CheckedChanged);
            // 
            // selectedAllRelation
            // 
            this.selectedAllRelation.AutoSize = true;
            this.selectedAllRelation.Location = new System.Drawing.Point(287, 84);
            this.selectedAllRelation.Name = "selectedAllRelation";
            this.selectedAllRelation.Size = new System.Drawing.Size(48, 16);
            this.selectedAllRelation.TabIndex = 13;
            this.selectedAllRelation.Text = "全选";
            this.selectedAllRelation.UseVisualStyleBackColor = true;
            this.selectedAllRelation.CheckedChanged += new System.EventHandler(this.selectedAllRelation_CheckedChanged);
            // 
            // GenerateMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 422);
            this.Controls.Add(this.selectedAllRelation);
            this.Controls.Add(this.selectedAllModules);
            this.Controls.Add(this.btn_SelectFinish);
            this.Controls.Add(this.checkedListBox_Relation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox_Module);
            this.Name = "GenerateMapForm";
            this.Text = "生成云图";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_Module;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox_Relation;
        private System.Windows.Forms.Button btn_SelectFinish;
        private System.Windows.Forms.CheckBox selectedAllModules;
        private System.Windows.Forms.CheckBox selectedAllRelation;
    }
}