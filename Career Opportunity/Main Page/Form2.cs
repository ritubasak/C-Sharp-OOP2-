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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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
                errorProvider2.SetError(this.textBox2, "Enter Your Userame Please!");
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
                errorProvider3.SetError(this.textBox3, "Enter Your Email Please!");
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
                errorProvider4.SetError(this.textBox4, "Enter Your Phone Number Please!");
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
                errorProvider5.SetError(this.textBox5, "Please Enter Your Password using (UPPERCASE,lowercase,numbers and special characters)!");
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
                errorProvider6.SetError(this.textBox6, "Enter Your Confirm Password Please!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;

            switch (status)
            {
                case true:
                    textBox6.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox6.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your Company Name Please!");
            }
            else if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Your Userame Please!");
            }
            else if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Your Email Please!");
            }
            else if(string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter Your Phone Number Please!");
            }
            else if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox4, "Enter Your Password Please!");
            }
            else if (textBox5.Text != textBox6.Text)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Password is not Matching!");
            }
            else
            {
                string signupCs = ConfigurationManager.ConnectionStrings["dbcss"].ConnectionString;
                SqlConnection signupCon = new SqlConnection(signupCs);

                string signupQuery2 = "select * from registration where username=@username";
                SqlCommand signupCmd2 = new SqlCommand(signupQuery2, signupCon);
                signupCmd2.Parameters.AddWithValue("@username", textBox2.Text);
                signupCon.Open();
                SqlDataReader rd = signupCmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show(textBox2.Text + "UserName Already Exit!", "Failed! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    signupCon.Close();
                }
                else
                {
                    signupCon.Close();
                    string signupQuery = "insert into registration values (@name,@username,@email,@number,@pass)";
                    SqlCommand signupCmd = new SqlCommand(signupQuery, signupCon);
                    signupCmd.Parameters.AddWithValue("@name", textBox1.Text);
                    signupCmd.Parameters.AddWithValue("@username", textBox2.Text);
                    signupCmd.Parameters.AddWithValue("@email", textBox3.Text);
                    signupCmd.Parameters.AddWithValue("@number", textBox4.Text);
                    signupCmd.Parameters.AddWithValue("@pass", textBox5.Text);
                    signupCon.Open();
                    int a = signupCmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Registration is Done Successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Hide();
                        Form5 f5 = new Form5();
                        f5.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registration is Failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    signupCon.Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
