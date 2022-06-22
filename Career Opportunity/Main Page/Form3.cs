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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Fill The Name!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider2.SetError(this.textBox6, "Please Fill The UserName!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Please Fill The Email!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
                errorProvider4.SetError(this.textBox7, "Please Fill The Contact Number!");
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

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Focus();
                errorProvider6.SetError(this.textBox8, "Enter Your Confirm Password Please!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void label10_Click(object sender, EventArgs e)
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
                    textBox8.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox8.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
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
                errorProvider1.SetError(this.textBox1, "Please Fill The Name!");
            }
            else if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider2.SetError(this.textBox6, "Please Fill The UserName!");
            }
            else if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Please Fill The Email!");
            }
            else if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider4.SetError(this.textBox7, "Please Fill The Contact Number!");
            }
            else if (comboBox2.SelectedItem == null)
            {
                comboBox2.Focus();
                errorProvider7.SetError(this.comboBox2, "Please select your Gender! ");
            }
            else if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider7.SetError(this.textBox4, "Please Enter your password!");
            }
            else if (textBox5.Text != textBox8.Text)
            {
                textBox8.Focus();
                errorProvider6.SetError(this.textBox8, "Password is not Matching!");
            }
            else
            {
                string signupCs = ConfigurationManager.ConnectionStrings["dbcss"].ConnectionString;
                SqlConnection signupCon = new SqlConnection(signupCs);

                string signupQuery2 = "select * from j_registration where username=@username";
                SqlCommand signupCmd2 = new SqlCommand(signupQuery2, signupCon);
                signupCmd2.Parameters.AddWithValue("@username", textBox6.Text);
                signupCon.Open();
                SqlDataReader rd = signupCmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show(textBox6.Text + "UserName Already Exit!", "Failed! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    signupCon.Close();
                }
                else
                {
                    signupCon.Close();
                    string signupQuery = "insert into j_registration values (@name,@username,@email,@number,@gender,@pass)";
                    SqlCommand signupCmd = new SqlCommand(signupQuery, signupCon);
                    signupCmd.Parameters.AddWithValue("@name", textBox1.Text);
                    signupCmd.Parameters.AddWithValue("@username", textBox6.Text);
                    signupCmd.Parameters.AddWithValue("@email", textBox4.Text);
                    signupCmd.Parameters.AddWithValue("@number", textBox7.Text);
                    signupCmd.Parameters.AddWithValue("@gender", comboBox2.SelectedItem);
                    signupCmd.Parameters.AddWithValue("@pass", textBox8.Text);

                    signupCon.Open();
                    int a = signupCmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Registration is Done Successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
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
            textBox6.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox1.Clear();
            comboBox2.SelectedItem = null;
            textBox5.Clear();
            textBox8.Clear();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                comboBox2.Focus();
                errorProvider7.SetError(this.comboBox2, "Please select your Gender!");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }
    }
}
