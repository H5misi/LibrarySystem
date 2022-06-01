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
    public partial class AvailableBooks : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;
        
        string customerUsername;

        private void dataGridView1_Filling()
        {
            ds.Clear();
            da = new SqlDataAdapter("Select * from BooksInfo", con);
            da.Fill(ds, "BookInfo");
            dataGridView1.DataSource = ds.Tables["BooksInfo"];
        }
        
        public AvailableBooks()
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

        public AvailableBooks(string CustomerUsername)
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

        private void AvailableBooks_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                con.ChangeDatabase("LibrarySystem");

                dataGridView1_Filling();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[5].Value.ToString() == "Available")
                {
                    con.Open();
                    con.ChangeDatabase("LibrarySystem");
                    cmd = new SqlCommand("insert into BorrowedBooks(customerUsername, bookId, bookName, borrowDate, returnDeadline) values (" + customerUsername + (int)dataGridView1.SelectedRows[0].Cells[0].Value + ",'" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "','" + DateTime.Now.Date.ToShortDateString() + "','" + DateTime.Now.AddDays(14).ToShortDateString() + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrowed successfully");
                    cmd = new SqlCommand("update BooksInfo set Availability = 'Not Available' where bookId = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), con);
                    cmd.ExecuteNonQuery();
                    dataGridView1_Filling();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("This book isn't available.");
                }
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
