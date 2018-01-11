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
    public partial class NewProjectForm : Form
    {
        private MainForm paf;
        public NewProjectForm(MainForm parent)
        {
            InitializeComponent();
            paf = parent;
        }

        public MainForm parent { get; set; }

        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            dbSelfPath = folderBrowserDialog1.SelectedPath;
            textBox2.Text = dbSelfPath;
        }

        public static string dbPath;
        public static string dbName;
        string dbSelfPath;
        SQLiteConnection conn = null;

        private void btnNewProjectSure_Click(object sender, EventArgs e)
        {
            connect_open_db();
            string sql = "CREATE TABLE IF NOT EXISTS modules(name varchar(50) PRIMARY KEY, " +
                "type varchar(50), level INTEGER, comment varchar(100) ); ";//建表语句
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表

            string sq2 = "CREATE TABLE IF NOT EXISTS relation(sourceName STRING NOT NULL, " +
                "targetName STRING NOT NULL, name varchar(50), bidirection varchar(50), type varchar(50), " +
                "comment varchar(100), PRIMARY KEY(sourceName, targetName),FOREIGN KEY (sourceName) " +
                "REFERENCES modules(name) on delete cascade on update cascade, " +
                "FOREIGN KEY(targetName) REFERENCES modules(name) on delete cascade on update cascade); ";//建表语句
            
            SQLiteCommand cmdCreateTable2 = new SQLiteCommand(sq2, conn);
            cmdCreateTable2.ExecuteNonQuery();//如果表不存在，创建数据表

            string sq3 = "PRAGMA foreign_keys = 'on';";
            SQLiteCommand cmdOpenCascade = new SQLiteCommand(sq3, conn);
            cmdOpenCascade.ExecuteNonQuery();

            close_db();
            this.Hide();
        }

        public void connect_open_db()
        {   
            dbName = dbName + ".db";
            dbPath = "Data Source = " + dbSelfPath + dbName;
            //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建
        }

        public void close_db()
        {
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dbName = textBox1.Text;
        }
    }
}
