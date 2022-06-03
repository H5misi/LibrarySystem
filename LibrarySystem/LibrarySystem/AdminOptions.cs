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
    public partial class AdminOptions : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;
        

        public AdminOptions()
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


        private void AdminOptions_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerDashboard cd = new CustomerDashboard();
            cd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookDashboard bookDashboard = new BookDashboard();
            bookDashboard.Show();
            this.Hide();
        }

        
    }
}
