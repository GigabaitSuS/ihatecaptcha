using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double result = 0;
        string l3text = "";

        public void Translate(double m)
        {
            if (comboBox2.Text == "м" || comboBox2.Text == "см" || comboBox2.Text == "дм" || comboBox2.Text == "км")
            {
                if (comboBox2.Text == "м")
                    result = m;
                if (comboBox2.Text == "см")
                    result = m * 1000000;
                if (comboBox2.Text == "дм")
                    result = m * 1000;
                if (comboBox2.Text == "км")
                    result = m / 1000000000;
                l3text = result.ToString();
            }                
            else l3text = "ед изм неверны";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            switch (comboBox1.Text)
            {
                case "м":
                    Translate(a);
                    break;
                case "см":
                    a /= 1000000;
                    Translate(a);
                    break;
                case "дм":
                    a /= 1000;
                    Translate(a);
                    break;
                case "км":
                    a *= 1000000000;
                    Translate(a);
                    break;
                default:
                    l3text = "ед изм неверны";
                    break;
            }            
            label3.Text = l3text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "," || textBox1.Text == "0")
                button1.Enabled = false;
            else button1.Enabled = true;
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
    }
}
