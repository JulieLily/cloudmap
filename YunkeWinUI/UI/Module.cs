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
    public partial class ModuleEditForm : Form
    {
        private MainForm paf;
        public ModuleEditForm(MainForm parent)
        {
            InitializeComponent();
            paf = parent;
            //string[] text = NewProjectForm.dbName.Split('.');
            //textBox_ProjectName.Text = text[0];
            //connect_open_db();
            //flushDataGrid();
        }

        public MainForm parent { get; set; }

        string moduleName;
        string moduleType;
        string moduleLevel;
        string moduleComment;
        string selectModule;
        //public static Item[] modulesName;
        public static string[] modulesList;
        public static SQLiteConnection conn = null;


        private void comboBox_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            moduleLevel = comboBox_Level.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            moduleComment = text_comment.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_modules();
            clearAllWidget();
            flushDataGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //update_modules();
            //clearAllWidget();
            //flushDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //insert_modules(sender);
            //clearAllWidget();
            //flushDataGrid();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            moduleName = name.Text;
        }

        public static bool isPress = false;
        private void btn_EditModuleFinish_Click(object sender, EventArgs e)
        {
            
        }

        private void ModuleEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnModuleCommit_Click(object sender, EventArgs e)
        {
            //read_modules(); //读取moduleList传到relation中
            //close_db();
            //this.Hide();
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            moduleType = comboBox_Type.Text;
        }

        public void insert_modules(object sender)
        {
            if(moduleName == null || moduleType == null || moduleLevel == null || moduleComment == null)
            {
                MessageBox.Show(" 所有的属性都不能为空！！ ", "使用帮助", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                string name = "'" + moduleName + "',";
                string type = "'" + moduleType + "',";
                string level = moduleLevel + ",";
                string comment = "'" + moduleComment + "'";
                cmdInsert.CommandText = "INSERT INTO modules VALUES(" + name + type + level + comment + ")";
                cmdInsert.ExecuteNonQuery();
            }
        }

        public void delete_modules()
        {
            SQLiteCommand cmdDelete = new SQLiteCommand(conn);
            string condition = @"name = '" + selectModule + "'";
            cmdDelete.CommandText = "DELETE FROM modules WHERE " + condition;
            cmdDelete.ExecuteNonQuery();
        }

        public void update_modules()
        {
            SQLiteCommand cmdUpdate = new SQLiteCommand(conn);
            string change = @"name = '" + moduleName + "'," + "type = '" + moduleType + "'," + "level = " + moduleLevel + "," + "comment = '" + moduleComment + "'";
            string condition = @"name = '" + selectModule + "'";
            cmdUpdate.CommandText = "UPDATE modules SET " + change + " WHERE " + condition;
            Console.WriteLine(cmdUpdate.CommandText);
            cmdUpdate.ExecuteNonQuery();
        }

        public static void read_modules()
        {
            int num = 0;
            string sql0 = "select count(*) from modules";
            SQLiteCommand cmdQ0 = new SQLiteCommand(sql0, conn);
            SQLiteDataReader reader0 = cmdQ0.ExecuteReader();
            while (reader0.Read())
            {
                num = reader0.GetInt32(0);
            }

            modulesName = new Item[num];
            modulesList = new string[num];
            int i = 0;
            string sql = "select name from modules";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

            SQLiteDataReader reader = cmdQ.ExecuteReader();
            while (reader.Read())
            {
                modulesName[i] = new Item(reader.GetString(0));
                modulesList[i] = reader.GetString(0);
                i = i + 1;
                //Console.WriteLine(reader[0]);
            }
        }

        public void read_record()
        {
            string condition = @"name = '" + selectModule + "'";
            string sql = "SELECT * FROM modules WHERE " + condition;
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name.Text = reader.GetString(0);
                comboBox_Type.Text = reader.GetString(1);
                comboBox_Level.Text = reader.GetInt32(2).ToString();
                int count = reader.FieldCount;
                if (count == 4)
                {
                    text_comment.Text = reader.GetString(3);
                }
            }
        }

        public class Item
        {
            private string text;
            public Item(string text)
            {
                this.text = text;
            }
            public string Text
            {
                get
                {
                    return text;
                }
            }
        }

        public void flushDataGrid()
        {
            read_modules();
            dataGridView_module.AutoGenerateColumns = true;
            dataGridView_module.DataSource = modulesName;
            dataGridView_module.Columns[0].HeaderText = "moduleName";
        }

        private void clearAllWidget()
        {
            comboBox_Level.Text = null;
            name.Text = null;
            comboBox_Type.Text = null;
            text_comment.Text = null;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectModule = dataGridView_module.CurrentCell.Value.ToString();
            //dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            read_record();
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

        private void textBox_ProjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
