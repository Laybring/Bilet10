using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace datagridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void loaddata()
        {
            using (DataBase db = new DataBase())
            {
                DataTable users = db.ExecuteSql("SELECT * FROM USERS");
                dataGridView1.DataSource = users;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                DataTable users = db.ExecuteSql("SELECT * FROM USERS");
                dataGridView1.DataSource = users;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateForm create = new CreateForm();
            create.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                int num = dataGridView1.CurrentCell.RowIndex;
                db.ExecuteSqlNonQuery($"DELETE FROM USERS WHERE ID={num + 1};");
                DataTable users = db.ExecuteSql("SELECT * FROM USERS");
                loaddata();
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {

                int num = dataGridView1.CurrentCell.RowIndex;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    db.ExecuteSqlNonQuery($"UPDATE users SET login = '"
                    + dataGridView1.Rows[i].Cells["login"].Value + "', password = '"
                    + dataGridView1.Rows[i].Cells["password"].Value + "', mail = '"
                    + dataGridView1.Rows[i].Cells["mail"].Value + "' WHERE ID =  "+ num+1 +";");
                }
                loaddata();
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
        }
    }
}
       