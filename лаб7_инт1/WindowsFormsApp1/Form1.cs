using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            label3.Text = $"в куб см = {(a * 1000000).ToString()}\n\nв куб дм = {(a / 1000).ToString()}\n\nв куб км = {(a / 1000000000).ToString()}";            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = ((System.Windows.Forms.TextBox)sender).Text;
            if (e.KeyChar >= '1' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == '0' && text != "")
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            if (e.KeyChar == (char)Keys.Enter)
                button1.Focus();
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',' && text.IndexOf(',') == -1 && text != "")
                return;
            e.KeyChar = '\0';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "," || textBox1.Text == "0")
                button1.Enabled = false;
            else button1.Enabled = true;            
        }
    }
}
