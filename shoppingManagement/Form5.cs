using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.IO;

namespace shoppingManagement
{
    public partial class Form5 : Form
    {
       
        public Form5()
        {
            InitializeComponent();
            
           
        }

        public void connection()
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
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connstr ="Data Source= (DESCRIPTION ="+
        "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-2V34OVD)(PORT = 1521))" +
         "(CONNECT_DATA ="+
            "(SERVER = DEDICATED)"+
            "(SERVICE_NAME = XE)" +
    ")"+
    "); User Id=HR; Password=hr";
            OracleConnection con = new OracleConnection(connstr);

            try
            {
                string sql = "INSERT INTO product (id,type,model,memory,price) values (" + txtId.Text + ", '" + txtType.Text + "','" + txtModel.Text + "','" + txtMemory.Text + "'," + txtPrice.Text + ")"; 
                OracleCommand cmd = new OracleCommand(sql, con);
                //OracleDataAdapter adapter = new OracleDataAdapter("select * from product", con);

                con.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Add new record done !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OracleDataAdapter adapter = new OracleDataAdapter("select * from product", con);
                DataTable dt = new DataTable();
                
                adapter.Fill(dt);


                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection();
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
             * 

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtType.SelectedIndex = -1;
            txtModel.Text="";
            txtMemory.SelectedIndex = -1;
            txtPrice.Text = "";

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstr = "Data Source= (DESCRIPTION =" +
       "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-2V34OVD)(PORT = 1521))" +
        "(CONNECT_DATA =" +
           "(SERVER = DEDICATED)" +
           "(SERVICE_NAME = XE)" +
   ")" +
   "); User Id=HR; Password=hr";
            OracleConnection con = new OracleConnection(connstr);

            try
            {
                string sql = "DELETE FROM product Where (id=" + txtId.Text + ")";
                OracleCommand cmd = new OracleCommand(sql, con);
                //OracleDataAdapter adapter = new OracleDataAdapter("select * from product", con);

                con.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Remove Succesfully!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OracleDataAdapter adapter = new OracleDataAdapter("select * from product", con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);


                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtType.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtModel.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtMemory.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //txtCategory.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connstr = "Data Source= (DESCRIPTION =" +
        "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-2V34OVD)(PORT = 1521))" +
         "(CONNECT_DATA =" +
            "(SERVER = DEDICATED)" +
            "(SERVICE_NAME = XE)" +
    ")" +
    "); User Id=HR; Password=hr";
            OracleConnection con = new OracleConnection(connstr);

            try
            {
                string sql = "UPDATE  product SET  type='" + txtType.Text + "', model='" + txtModel.Text + "', memory='" + txtMemory.Text + "', price=" + txtPrice.Text + "WHERE (id=" + txtId.Text + ")";
                OracleCommand cmd = new OracleCommand(sql, con);
                //OracleDataAdapter adapter = new OracleDataAdapter("select * from product", con);

                con.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Succesful !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OracleDataAdapter adapter = new OracleDataAdapter("select * from product", con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);


                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
    
}
