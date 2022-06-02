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

    public partial class BookDashboard : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;
        
        public BookDashboard()
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

        private void BookDashboard_Load(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("create table BooksInfo( bookId int primary Key , bookName varchar(255), authorName varchar(255), publication varchar(255), purchaseDate varchar(255), Availability varchar(50))", con);
                cmd.ExecuteNonQuery();

                populate();

            }
            catch
            {
                
            }
            populate();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void populate()
        {

            //string daStr = "select * from Books";
            da = new SqlDataAdapter(/*daStr*/"select * from BooksInfo", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("insert into BooksInfo(bookId, bookName, authorName, publication, purchaseDate, Availabilty) values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text.ToString() + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added succeeded");

                populate();
                //da.Fill(ds, "students");

                //clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                //string cmdStr = "update Books set bookName='" + textBox2.Text + "' , authorName ='" + textBox3.Text + "' , publication ='" + textBox4.Text + "' , purchaseDate ='" + dateTimePicker1.Text + "' , bookPrice ='" + int.Parse(textBox5.Text) + "' , quantBook ='" + int.Parse(textBox6.Text) + "' where bookId=" + Convert.ToInt32(textBox1.Text);
                cmd = new SqlCommand(/*cmdStr*/"update BooksInfo set bookName='" + textBox2.Text + "' , authorName ='" + textBox3.Text + "' , publication ='" + textBox4.Text + "' , purchaseDate ='" + dateTimePicker1.Text + "' , Availability ='" + comboBox1.SelectedItem.ToString() + "' where bookId=" + Convert.ToInt32(textBox1.Text), con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated succeeded");
                populate();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //string cmdStr = "Delete from BooksInfo Where bookId =" + Convert.ToInt32(textBox1.Text);
                cmd = new SqlCommand(/*cmdStr*/"Delete from BooksInfo Where bookId =" + Convert.ToInt32(textBox1.Text), con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete succeeded");
                populate();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminOptions ao = new AdminOptions();
            ao.Show();
            this.Hide();
        }
    }
}
