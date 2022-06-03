using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class CustomerDashboard : Form
    {
        SqlConnection con = new SqlConnection("server = HAZEM-ALKHAMISI; database = LibrarySystem; integrated security = true");

        SqlDataAdapter da;

        DataSet ds;

        SqlCommand cmd;


        
        public CustomerDashboard()
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

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("create table CustomersInfo( customerId int primary Key ,customerName varchar(255), dateBirth varchar(255), customerContact int, customerEmail varchar(255), customerImage image)", con);
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

            //string daStr = "select * from Customers";
            da = new SqlDataAdapter(/*daStr*/"select * from CustomersInfo", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] images = ms.ToArray();
                
                cmd = new SqlCommand("insert into CustomersInfo(customerId, customerName, dateBirth, customerContact, customerEmail, customerImage) values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + int.Parse(textBox3.Text) + "','" + textBox4.Text + "', @images)", con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.ExecuteNonQuery();
                MessageBox.Show("data added sucessfully");

                populate();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Text = string.Empty;






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
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] images = ms.ToArray();
                
                
                //string cmdStr = "update Customers set customerName='" + textBox2.Text + "', cutomerDepartment ='" + textBox3.Text + "' , customerGrade ='" + textBox4.Text + "' , customerContact ='" + textBox5.Text + "' , customerEmail ='" + textBox6.Text + "' , customerImage =@images where CustomerId=" + Convert.ToInt32(textBox1.Text);
                cmd = new SqlCommand(/*cmdStr*/"update CustomersInfo set customerName='" + textBox2.Text + "', customerContact ='" + textBox3.Text + "' , customerEmail ='" + textBox4.Text + "' , customerImage =@images where CustomerId=" + Convert.ToInt32(textBox1.Text), con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.ExecuteNonQuery();
                populate();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Text = string.Empty;
                
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
                //string cmdStr = "delete from Customers where customerId=" + Convert.ToInt32(textBox1.Text);
                cmd = new SqlCommand(/*cmdStr*/"delete from CustomersInfo where customerId=" + Convert.ToInt32(textBox1.Text), con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete suceeded");
                populate();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Text = string.Empty;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(.png)|*.png|jpg files(.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminOptions ao = new AdminOptions();
            ao.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[5].Value);
                pictureBox1.Image = Image.FromStream(ms);

            }
        }
    }
}
