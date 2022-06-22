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
    public partial class Form6 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcss"].ConnectionString;
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your First Name Please!");
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
                errorProvider2.SetError(this.textBox2, "Enter Your Last Name Please!");
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
                errorProvider3.SetError(this.textBox3, "Enter Your Current Address Please!");
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
                errorProvider4.SetError(this.textBox4, "Enter Your Email Address Please!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Enter Your Contact Number Please!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Enter Your CGPA Please!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Enter Your Others Info Please!");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void Division_Leave(object sender, EventArgs e)
        {

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Focus();
                errorProvider9.SetError(this.textBox8, "Enter Your CGPA Please!");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.Focus();
                errorProvider10.SetError(this.textBox9, "Enter Your Selected Company Name Please!");
            }
            else
            {
                errorProvider10.Clear();
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                textBox10.Focus();
                errorProvider11.SetError(this.textBox10, "Enter Your Applying For Position Please!");
            }
            else
            {
                errorProvider11.Clear();
            }
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(button2.Text))
            {
                button2.Focus();
                errorProvider12.SetError(this.button2, "Enter Your Upload Image Please!");
            }
            else
            {
                errorProvider12.Clear();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Select Image";
            of.Filter = "Image File(All files) *.* | *.*";

            if(of.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(of.FileName);
            }   
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_Leave(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your First Name Please!");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Your Last Name Please!");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Your Current Address Please!");
            }
            else if(string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Enter Your Contact Number Please!");
            }
            else if(string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Enter Your CGPA Please!");
            }
            else if(string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Enter Your Others Info Please!");
            }
            else if(string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Focus();
                errorProvider9.SetError(this.textBox8, "Enter Your CGPA Please!");
            }
            else if(string.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.Focus();
                errorProvider10.SetError(this.textBox9, "Enter Your Selected Company Name Please!");
            }
            else if (string.IsNullOrEmpty(textBox10.Text))
            {
                textBox10.Focus();
                errorProvider11.SetError(this.textBox10, "Enter Your Applying For Position Please!");
            }
            else if (string.IsNullOrEmpty(button2.Text))
            {
                button2.Focus();
                errorProvider12.SetError(this.button2, "Enter Your Upload Image Please!");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert into Employee_Details values(@fname,@lname,@address,@email,@number,@age,@graduation,@masters,@others,@cname,@position,@picture)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@address", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@number", textBox5.Text);
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@graduation", textBox6.Text);
                cmd.Parameters.AddWithValue("@masters", textBox8.Text);
                cmd.Parameters.AddWithValue("@others", textBox7.Text);
                cmd.Parameters.AddWithValue("@cname", textBox9.Text);
                cmd.Parameters.AddWithValue("@position", textBox10.Text);
                cmd.Parameters.AddWithValue("@picture", SavePhoto());

                con.Open();

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Submitted successfully!");
                }
                else
                {
                    MessageBox.Show("Data not Submitted successfully!");
                }
            }
        }

        private Byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            numericUpDown1.Value = 0;
            pictureBox1.Image = Properties.Resources.avatars_000373844735_9n06kq_t240x240;
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {


         }

    }
}
