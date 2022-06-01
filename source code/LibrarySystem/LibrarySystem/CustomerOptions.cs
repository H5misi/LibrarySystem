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
    public partial class CustomerOptions : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;
        
        string customerUsername;


        public CustomerOptions()
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
        
        
        public CustomerOptions(string customerUsername)
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

        private void CustomerOptions_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("create table BorrowedBooks(customerUsername varchar(50), bookId int unique, bookName varchar(255), borrowDate varchar(255), returnDeadline)");
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrowedBooks borrowedBooks = new BorrowedBooks(customerUsername);
            borrowedBooks.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AvailableBooks availableBooks = new AvailableBooks(customerUsername);
            availableBooks.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
