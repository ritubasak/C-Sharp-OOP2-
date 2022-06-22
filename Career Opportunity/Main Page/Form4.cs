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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your Userame Please!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }


        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Your Password Please!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;

            switch (status)
            {
                case true:
                    textBox3.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox3.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string signupCs = ConfigurationManager.ConnectionStrings["dbcss"].ConnectionString;
            SqlConnection signupCon = new SqlConnection(signupCs);

            string signupQuery2 = "select * from j_registration where username=@username and pass=@pass";
            SqlCommand signupCmd2 = new SqlCommand(signupQuery2, signupCon);
            signupCmd2.Parameters.AddWithValue("@username", textBox1.Text);
            signupCmd2.Parameters.AddWithValue("@pass", textBox3.Text);



            signupCon.Open();

            SqlDataReader rd = signupCmd2.ExecuteReader();
            if (rd.HasRows == true)
            {
                MessageBox.Show("Login is Done Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Login is Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            signupCon.Close();
        }
    }
}
