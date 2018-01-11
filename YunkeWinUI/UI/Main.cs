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
    public partial class MainForm : Form
    {
        public static int panelWidth;
        public static int panelHeight;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelWidth = panel4.Size.Width;
            panelHeight = panel4.Size.Height;
            textBox2.Text = panel4.Size.Width.ToString() + " * " + panel4.Size.Height.ToString();
            //panel1.Left = 0;
            //panel1.Top = 25;
        }
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void NToolStripMenuItem_newProject_Click(object sender, EventArgs e)
        {
            NewProjectForm newProjrctFrom = new NewProjectForm(this);
            newProjrctFrom.ShowDialog();

            ModuleEditForm newModuleEditForm = new ModuleEditForm(this);
            newModuleEditForm.ShowDialog();

            RelationEditForm newRelationEditForm = new RelationEditForm(this);
            newRelationEditForm.ShowDialog();

                
        }

        private void ToolStripMenuItem_import_Click(object sender, EventArgs e)
        {
            importForm import = new importForm(this);

            import.ShowDialog();
        }

        private void ToolStripMenuItem_OpenProject_Click(object sender, EventArgs e)
        {
            openFileDialog_OpenProject.ShowDialog();
            string[] text = openFileDialog_OpenProject.FileName.Split('\\');
            NewProjectForm.dbName = text[text.Length - 1];

            NewProjectForm.dbPath = "Data Source = " + openFileDialog_OpenProject.FileName;
        }

        private void ToolStripMenuItem_SaveProject_Click(object sender, EventArgs e)
        {
            //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog_SaveProject.OpenFile();
            saveFileDialog_SaveProject.ShowDialog();
        }

        private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog_SaveProject.ShowDialog();
        }

        private void 保存云图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog_saveImage.ShowDialog();
        }

        private void ToolStripMenuItem_Print_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();   
        }
        private void ToolStripMenuItem_PrePrint_Click(object sender, EventArgs e)
        {
             printPreviewDialog1.ShowDialog();  
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定退出系统？", "企业云图", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                System.Environment.Exit(0);
        }
   
        private void ToolStripMenuItem_AddModule_Click(object sender, EventArgs e)
        {
            ModuleEditForm newModuleEditForm = new ModuleEditForm(this);

            newModuleEditForm.ShowDialog();  
        }

        private void ToolStripMenuItem_AddRelation_Click(object sender, EventArgs e)
        {
            RelationEditForm newRelationEditForm = new RelationEditForm(this);

            newRelationEditForm.ShowDialog();
        }

        private void ToolStripMenuItem_BorderColor_Click(object sender, EventArgs e)
        {
            BorderColor.ShowDialog();
        }

        private void ToolStripMenuItem_LineColor_Click(object sender, EventArgs e)
        {
            LineColor.ShowDialog();
        }

        private void ToolStripMenuItem_DisplayScale_Click(object sender, EventArgs e)
        {
            DisplayScaleForm displayScaleForm = new DisplayScaleForm(this);
            displayScaleForm.ShowDialog();

        }

        private void 注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("可视化系统之间的关系", "关于云图", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }
         
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 使用方式同记事本 ", "使用帮助", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定退出系统？", "企业云图", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                //Application.Exit();
                System.Environment.Exit(0);
            else
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void ToolStripMenuItem_File_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog_OpenProject_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        
        // Icon click events
        private void toolStripButton_newProject_Click(object sender, EventArgs e)
        {
            NToolStripMenuItem_newProject_Click(sender, e);
        }

        private void toolStripButton_openProject_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_OpenProject_Click(sender, e);
        }

        private void toolStripButton_saveProject_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_SaveProject_Click(sender, e);
        }

        private void toolStripButton_prePrint_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_PrePrint_Click(sender, e);
        }

        private void toolStripButton_import_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_import_Click(sender, e);
        }

        private void toolStripButton_addModule_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_AddModule_Click(sender, e);
        }

        private void toolStripButton_addRelation_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_AddRelation_Click(sender, e);
        }

        private void toolStripDropDownButton_colorFilling_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_BorderColor_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_DisplayScale_Click(sender, e);
        }

        private void toolStripButton_information_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_About_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            帮助ToolStripMenuItem_Click(sender, e);
        }

        private void saveFileDialog_SaveProject_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripButton_saveImage_Click(object sender, EventArgs e)
        {
            保存云图ToolStripMenuItem_Click(sender,e);
        }

        private void toolStripDropDownButton_comment_Click(object sender, EventArgs e)
        {
            注释ToolStripMenuItem_Click(sender,e);
        }

        private void toolStripDropDownButton_borderLIne_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_BorderColor_Click(sender,e);
        }

        private void toolStripDropDownButton_lineColor_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_LineColor_Click(sender,e);
        }

        private void btn_generateMap_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Level1_Click(object sender, EventArgs e)
        {

        }




    }
}
