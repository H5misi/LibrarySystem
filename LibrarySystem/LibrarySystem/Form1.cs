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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = master; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;
        public Login()
        {
            InitializeComponent();
            
            try
            {
                con.Open();
                //MessageBox.Show("Connection " + con.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("create database LibrarySystem", con);
                cmd.ExecuteNonQuery();
                cmd.Connection.ChangeDatabase("LibrarySystem");

                MessageBox.Show("Database Created");

            }
            catch
            {
                cmd.Connection.ChangeDatabase("LibrarySystem");

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            this.Hide();
        }
    }
}
