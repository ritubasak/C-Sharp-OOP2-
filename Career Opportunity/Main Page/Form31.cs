using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Main_Page
{
    public partial class Form31 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcss"].ConnectionString;
        public Form31()
        {
            InitializeComponent();
            BindGridView();
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your Company Name Please!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Your Job Title Please!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Your Job Location Please!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter Your Contact Number Please!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Select Logo";
            of.Filter = "IMAGE FILE(All files) *.* | *.*";
            //of.ShowDialog();
            if(of.ShowDialog()==DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(of.FileName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your Company Name Please!");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Your Job Title Please!");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Your Job Location Please!");
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter Your Contact Number Please!");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert into Company_Details values(@name,@id,@title,@location,@number,@salary,@logo)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", textBox5.Text);
                cmd.Parameters.AddWithValue("@title", textBox2.Text);
                cmd.Parameters.AddWithValue("@location", textBox3.Text);
                cmd.Parameters.AddWithValue("@number", textBox4.Text);
                cmd.Parameters.AddWithValue("@salary", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@logo", SavePhoto());

                con.Open();

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data inserted successfully!");
                    BindGridView();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data not inserted successfully!");
                }
            }

        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms,pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Company_Details";
            SqlDataAdapter sd = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sd.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            numericUpDown1.Value = 0;
            pictureBox2.Image = Properties.Resources.acdvd;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
            pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);

        }

        private Image GetPhoto(byte[] p)
        {
            MemoryStream ms = new MemoryStream(p);
            return Image.FromStream(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update Company_Details set company_name=@name,id=@id,job_title=@title,job_location=@location,contact_number=@number,salary=@salary,add_logo=@logo where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);
            cmd.Parameters.AddWithValue("@title", textBox2.Text);
            cmd.Parameters.AddWithValue("@location", textBox3.Text);
            cmd.Parameters.AddWithValue("@number", textBox4.Text);
            cmd.Parameters.AddWithValue("@salary", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@logo", SavePhoto());

            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data updated successfully!");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not updated successfully!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Company_Details where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);

            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a >= 0)
            {
                MessageBox.Show("Data deleted successfully!");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not deleted successfully!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Enter Your ID Please!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
