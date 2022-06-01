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
    public partial class BorrowedBooks : Form
    {

        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;
        
        
        string customerUsername;

        
        public BorrowedBooks()
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

        public BorrowedBooks(string CustomerUsername)
        {
            customerUsername = CustomerUsername;
            
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

        private void BorrowedBooks_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void populate()
        {  
            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select * from Borrow", con);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delete from BorrowedBooks where bookId ' " + dataGridView1.SelectedRows[0].Cells[1].Value + "' ", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update BooksInfo set Availability = 'Available' where bookId = '" + dataGridView1.SelectedRows[0].Cells[1].Value + "' ", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Book returned successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerOptions customerOptions = new CustomerOptions(customerUsername);
            customerOptions.Show();
            this.Hide();
        }
    }
}
