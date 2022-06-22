using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Page
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form42 f42 = new Form42();
            f42.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form43 f43 = new Form43();
            f43.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form44 f44 = new Form44();
            f44.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form45 f45 = new Form45();
            f45.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form46 f46 = new Form46();
            f46.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form47 f47 = new Form47();
            f47.Show();
            this.Hide();
        }
    }
}
