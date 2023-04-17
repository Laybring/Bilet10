using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datagridview
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            try
            {
                using (DataBase db = new DataBase())
                {
                    db.ExecuteSqlNonQuery($"INSERT INTO USERS VALUES('{login}','{password}')");
                }
                this.Close();
                Form1 main = new Form1();
                main.Refresh();
            }
            catch
            { 
                MessageBox.Show("Проверьте корректность введнённых данных."); 
            }

        }
    }
    
}
