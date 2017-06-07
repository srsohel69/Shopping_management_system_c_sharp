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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
{
    
}

        private void Form6_Load(object sender, EventArgs e)
        {
           /* string connstr = "Data Source=(DESCRIPTION=" +
         "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-2V34OVD)(PORT = 1521))" +
          "(CONNECT_DATA =" +
             "(SERVER = DEDICATED)" +
             "(SERVICE_NAME = XE)" +
     ")" +
     "); User Id=HR; Password=hr";
            OracleConnection con = new OracleConnection(connstr);
            try
            {


                string sql = "Select * from product";

                OracleDataAdapter adapter = new OracleDataAdapter(sql, con);


                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*dataGridView2.Rows.Clear();

            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                { 
                  int n=dataGridView2.Rows.Add();
                  dataGridView2.Rows[n].Cells[0].Value = item.Cells[0].Value.ToString();
                  dataGridView2.Rows[n].Cells[1].Value = item.Cells[1].Value.ToString();
                  dataGridView2.Rows[n].Cells[2].Value = item.Cells[2].Value.ToString();
                  dataGridView2.Rows[n].Cells[3].Value = item.Cells[3].Value.ToString();
                  dataGridView2.Rows[n].Cells[4].Value = item.Cells[4].Value.ToString();
                }
            }*/

            dataGridView2.Rows.Clear();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item.Cells[5].Value.ToString();

                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string connstr = "Data Source=(DESCRIPTION=" +
         "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-2V34OVD)(PORT = 1521))" +
          "(CONNECT_DATA =" +
             "(SERVER = DEDICATED)" +
             "(SERVICE_NAME = XE)" +
     ")" +
     "); User Id=HR; Password=hr";
            OracleConnection con = new OracleConnection(connstr);

            try
            {


                string sql = "Select * from product";

                OracleDataAdapter adapter = new OracleDataAdapter(sql, con);


                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                dataGridView1.Rows.Clear();
                foreach(DataRow item in dt.Rows)
                { 
                  int n=dataGridView1.Rows.Add();

                  dataGridView1.Rows[n].Cells[0].Value = false;
                  dataGridView1.Rows[n].Cells[1].Value = item["id"].ToString();
                  dataGridView1.Rows[n].Cells[2].Value = item["type"].ToString();
                  dataGridView1.Rows[n].Cells[3].Value = item["model"].ToString();
                  dataGridView1.Rows[n].Cells[4].Value = item["memory"].ToString();
                  dataGridView1.Rows[n].Cells[5].Value = item["price"].ToString();
                
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)dataGridView1.SelectedRows[0].Cells[0].Value == false)
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = true;
            }
            else
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = false;
            }
        }
    }
}
