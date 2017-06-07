using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace shoppingManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "Data Source=(DESCRIPTION=" +
         "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-2V34OVD)(PORT = 1521))" +
          "(CONNECT_DATA =" +
             "(SERVER = DEDICATED)" +
             "(SERVICE_NAME = XE)" +
     ")" +
     "); User Id=HR; Password=hr";
            try
            {
                OracleConnection con = new OracleConnection(connstr);
                OracleDataAdapter adapter = new OracleDataAdapter("Select count(*) from admin where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "' ", connstr);
                DataTable data = new DataTable();
                 adapter.Fill(data);
                 if (data.Rows[0][0].ToString() == "1")
                 {
                       this.Hide();
                       Form4 f4 = new Form4();
                       f4.ShowDialog();
                 }
                 else
                 {
                     MessageBox.Show("please check your username & password");

                 }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
