using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ShopDatabase
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

        private void button1_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop(textBox5.Text, textBox1.Text, textBox4.Text, textBox2.Text, textBox3.Text, new WorkTime((int)numericUpDown1.Value, (int)numericUpDown2.Value));
            if (Regex.Match(textBox1.Text, @"[0-9a-zA-ZА-яёЁ]").Success &&
                Regex.Match(textBox2.Text, @"[a-zA-ZА-яёЁ]").Success &&
                Regex.Match(textBox3.Text, @"[a-zA-ZА-яёЁ]").Success &&
                Regex.Match(textBox4.Text, @"[0-9a-zA-ZА-яёЁ]").Success &&
                Regex.Match(textBox5.Text, @"[a-zA-ZА-яёЁ]").Success
                )
            {
                Form1.shops.Add(shop);
            }            
            else
	        {
                MessageBox.Show("Введены неверные данные");
            }
            Close();
        }
    }
}
