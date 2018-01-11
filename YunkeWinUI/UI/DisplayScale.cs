using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudMaps
{
    public partial class DisplayScaleForm : Form
    {
        private MainForm paf;
        public DisplayScaleForm(MainForm parent)
        {
            InitializeComponent();
            paf = parent;
        }

        


        public MainForm parent { get; set; }
        private void btnDisplayScaleOK_Click(object sender, EventArgs e)
        {
            int newPanelWidth = (int)(MainForm.panelWidth * numericUpDown_DisplayScale.Value / 100);
            int newPanelHeight = (int)(MainForm.panelHeight * numericUpDown_DisplayScale.Value / 100);
            paf.panel4.Size = new Size(newPanelWidth, newPanelHeight);
            paf.textBox1.Text = newPanelWidth.ToString() + " * " + newPanelHeight.ToString();
            this.Hide();

        }

        private void btnDisplayScaleCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButton_50_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_50.Checked)
                numericUpDown_DisplayScale.Value = 50;
        }

        private void radioButton_100_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_100.Checked)
                numericUpDown_DisplayScale.Value = 100;
        }

        private void radioButton_150_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_150.Checked)
                numericUpDown_DisplayScale.Value = 150;
        }

        private void radioButton_200_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_200.Checked)
                numericUpDown_DisplayScale.Value = 200;
        }

        private void numericUpDown_DisplayScale_ValueChanged(object sender, EventArgs e)
        {
            radioButton_100.Checked = false;
            if (numericUpDown_DisplayScale.Value != 50 && numericUpDown_DisplayScale.Value != 100 && numericUpDown_DisplayScale.Value != 150 && numericUpDown_DisplayScale.Value != 200)
            {
                radioButton_150.Checked = false;
                radioButton_150.Checked = false;
                radioButton_150.Checked = false;
                radioButton_150.Checked = false;
            }  
            else if (numericUpDown_DisplayScale.Value == 200)
                radioButton_200.Checked = true;
            else if (numericUpDown_DisplayScale.Value == 150)
                radioButton_150.Checked = true;
            else if (numericUpDown_DisplayScale.Value == 100)
                radioButton_100.Checked = true;
            else if (numericUpDown_DisplayScale.Value == 50)
                radioButton_50.Checked = true;
        }
    }
}
