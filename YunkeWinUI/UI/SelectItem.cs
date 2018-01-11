using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CloudMaps
{
    public partial class GenerateMapForm : Form
    {
        private MainForm paf;
        public GenerateMapForm(MainForm parent)
        {
            InitializeComponent();
            paf = parent;
            connect_open_db();
            flushModuleList();
            flushRelationList();
        }

        private void btn_SelectFinish_Click(object sender, EventArgs e)
        {
            close_db();
            this.Hide();
        }

        public MainForm parent { get; set; }

        SQLiteConnection conn = null;

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            

        }

        private void SelectedModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox_Module_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void connect_open_db()
        {
            conn = new SQLiteConnection(NewProjectForm.dbPath);//创建数据库实例，指定文件位置
            conn.Open();
            string sq3 = "PRAGMA foreign_keys = 'on';";
            SQLiteCommand cmdOpenCascade = new SQLiteCommand(sq3, conn);
            cmdOpenCascade.ExecuteNonQuery();
        }

        private void close_db()
        {
            conn.Close();
        }


        public void flushModuleList()
        {
            ModuleEditForm.conn = conn;
            ModuleEditForm.read_modules();
            checkedListBox_Module.DataSource = ModuleEditForm.modulesList;
        }

        public void flushRelationList()
        {
            RelationEditForm.conn = conn;
            RelationEditForm.read_relation_source_target();
            checkedListBox_Relation.DataSource = RelationEditForm.relationList;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectedAll_CheckedChanged(object sender, EventArgs e)
        {
            if(selectedAllModules.Checked == true)
            {
                for (int j = 0; j < checkedListBox_Module.Items.Count; j++)
                    checkedListBox_Module.SetItemChecked(j, true);
            }
            else
            {
                for (int j = 0; j < checkedListBox_Module.Items.Count; j++)
                    checkedListBox_Module.SetItemChecked(j, false);
            }
        }

        private void selectedAllRelation_CheckedChanged(object sender, EventArgs e)
        {
            if(selectedAllRelation.Checked == true)
            {
                for (int j = 0; j < checkedListBox_Relation.Items.Count; j++)
                    checkedListBox_Relation.SetItemChecked(j, true);
            }
            else
            {
                for (int j = 0; j < checkedListBox_Relation.Items.Count; j++)
                    checkedListBox_Relation.SetItemChecked(j, false);
            }
        }
    }
}
