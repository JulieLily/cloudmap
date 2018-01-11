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
    public partial class RelationEditForm : Form
    {
        private MainForm paf;
        public RelationEditForm(MainForm parent)
        {
            InitializeComponent();
            //paf = parent;
            //string[] text = NewProjectForm.dbName.Split('.');
            //textBox_ProjectName.Text = text[0];
            //clearAllWidget();
            //connect_open_db();
            //flushList(); //对源和目的list进行初始化
            //flushDataGrid();
        }

        public MainForm parent { get; set; }

        string relationSource;
        string relationTarget;
        string relationName;
        string relationBidirection = null;
        string relationType;
        string relationComment;
        public static string[,] list;
        public static string[] relationList;
        string selectSource;
        string selectTarget;
        public static SQLiteConnection conn = null;

        private void RelationEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_EditRelationFinish_Click(object sender, EventArgs e)
        {
            flushList();
        }

        private void btnRelationCommit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            relationName = textBox_Name.Text;
        }

        private void comboBox_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            //relationSource = comboBox_Source.Text;
        }

        private void comboBox_Target_SelectedIndexChanged(object sender, EventArgs e)
        {
            //relationTarget = comboBox_Target.Text;
        }

        private void comboBox_Bidirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //relationBidirection = comboBox_Bidirection.Text;
            //if (comboBox_Bidirection.Text.Equals("no"))
            //{
            //    relationBidirection = 0; //代表单向
            //}
            //else
            //{
            //    relationBidirection = 1;
            //}
        }

        private void textBox_comment_TextChanged(object sender, EventArgs e)
        {
            relationComment = textBox_comment.Text;
        }

        public void insert_relations()
        {
            if (relationName == null || relationType == null || relationSource == null || relationTarget == null || relationComment == null)
            {
                MessageBox.Show(" 所有的属性都不能为空！！ ", "使用帮助", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                string name = "'" + relationName + "',";
                string source = "'" + relationSource + "',";
                string target = "'" + relationTarget + "',";
                if (relationBidirection == null)
                {
                    relationBidirection = "no";
                }
                string bidirection = "'" + relationBidirection + "',";
                string type = "'" + relationType + "',";
                string comment = "'" + relationComment + "'";
                cmdInsert.CommandText = "INSERT INTO relation VALUES(" + source + target + name + bidirection + type + comment + ")";
                cmdInsert.ExecuteNonQuery();
            }
        }

        public void delete_modules()
        {
            SQLiteCommand cmdDelete = new SQLiteCommand(conn);
            string condition1 = @"sourceName = '" + selectSource + "'";
            string condition2 = @"targetName = '" + selectTarget + "'";
            cmdDelete.CommandText = "DELETE FROM relation WHERE " + condition1 + " and " + condition2;
            cmdDelete.ExecuteNonQuery();
        }

        public void update_modules()
        {
            SQLiteCommand cmdDelete = new SQLiteCommand(conn);
            string change = @"sourceName = '" + relationSource + "'," + "targetName = '" + relationTarget + "',"  + "name = '" + relationName + "'," + "type = '" + relationType + "'," + "bidirection = '" + relationBidirection + "'," + "comment = '" + relationComment + "'";
            string condition1 = @"sourceName = '" + selectSource + "'";
            string condition2 = @"targetName = '" + selectTarget + "'";
            cmdDelete.CommandText = "UPDATE relation SET " + change + " WHERE " + condition1 + " and " + condition2;
            Console.WriteLine(cmdDelete.CommandText);
            cmdDelete.ExecuteNonQuery();
        }

        public static void read_relation_source_target()
        {
            int num = 0;
            string sql0 = "select count(*) from relation";
            SQLiteCommand cmdQ0 = new SQLiteCommand(sql0, conn);
            SQLiteDataReader reader0 = cmdQ0.ExecuteReader();
            while (reader0.Read())
            {
                num = reader0.GetInt32(0);
            }
            list = new string[num,2];
            relationList = new string[num];

            int i = 0;
            string sql = "select sourceName,targetName from relation";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

            SQLiteDataReader reader = cmdQ.ExecuteReader();
            while (reader.Read())
            {
                list[i, 0] = reader.GetString(0);
                list[i,1] = reader.GetString(1);
                relationList[i] = reader.GetString(0) + "--" + reader.GetString(1);
                i = i + 1;
            }
        }

        public void read_record_and_show()
        {
            //string condition1 = @"sourceName = '" + selectSource + "'";
            //string condition2 = @"targetName = '" + selectTarget + "'";
            //string sql = "SELECT * FROM relation WHERE " + condition1 + " and " + condition2;
            //SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    textBox_Name.Text = reader.GetString(2);
            //    comboBox_Source.Text = reader.GetString(0);
            //    comboBox_Target.Text = reader.GetString(1);
            //    comboBox_Bidirection.Text = reader.GetString(3);
            //    comboBox_type.Text = reader.GetString(4);
            //    int count = reader.FieldCount;
            //    if (count == 6)
            //    {
            //        textBox_comment.Text = reader.GetString(5);
            //    }
            //}
        }

        public void flushList()
        {
            //string[] modName = (string[])(ModuleEditForm.modulesList.Clone());
            //comboBox_Source.DataSource = ModuleEditForm.modulesList; 
            //comboBox_Target.DataSource = modName;
        }

        public void flushDataGrid()
        {
            //read_relation_source_target();
            //DataTable dt = new DataTable();
            //for (int i = 0; i < list.GetLength(1); i++)
            //    dt.Columns.Add(i.ToString(), typeof(string));
            //for (int i = 0; i < list.GetLength(0); i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    for (int j = 0; j < list.GetLength(1); j++)
            //        dr[j] = list[i, j];
            //    dt.Rows.Add(dr);
            //}
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].HeaderText = "sourceName";
            //dataGridView1.Columns[0].Width = 60;
            //dataGridView1.Columns[1].HeaderText = "targetName";
            //dataGridView1.Columns[1].Width = 60;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            insert_relations();
            clearAllWidget();
            flushDataGrid();
        }

        public void clearAllWidget()
        {
            //textBox_Name.Text = null;
            //comboBox_Source.Text = null;
            //comboBox_Target.Text = null;
            //comboBox_Bidirection.Text = "no";
            //comboBox_type.Text = null;
            //textBox_comment.Text = null;
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            relationType = comboBox_type.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //update_modules();
            //clearAllWidget();
            //flushDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete_modules();
            //clearAllWidget();
            //flushDataGrid();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            //selectTarget = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            //selectSource = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            //read_record_and_show();
        }

        private void connect_open_db()
        {
            //conn = new SQLiteConnection(NewProjectForm.dbPath);//创建数据库实例，指定文件位置
            //conn.Open();
        }

        private void close_db()
        {
            conn.Close();
        }

        private void textBox_Name_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            this.Hide();
        }
    }
}
