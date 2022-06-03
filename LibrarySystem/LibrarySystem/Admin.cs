using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;
        
        SqlCommand cmd;
        
        
        public Admin()
        {
            InitializeComponent();
            try
            {
                con.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("create table AdminLogin(userName varchar(255) unique, password varchar(255))", con);
                
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("insert into AdminLogin values('admin', 'admin')", con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from AdminLogin where userName = '" + textBox1.Text + "'and password = '" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                AdminOptions ao = new AdminOptions();
                ao.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
