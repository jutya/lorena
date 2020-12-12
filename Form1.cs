using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace test_combobox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double coint, coint1;

            try
            {
                coint = Convert.ToDouble(textBox1.Text);

                coint1 = coint - coint * 0.04;

                textBox2.Text = coint1.ToString("n");
            }
            catch
            {
                textBox1.Focus();
            }
            //c = conv double (textBox1.Text);
            //num = Console
            //тут прописываем передачу данных "название салона" и начальная цена, вызываем метод расчета и выводим результат в текстбокс2
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }

            //if (e.KeyChar == '.')
            //{
            //    e.KeyChar == ',';
            //}
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
                        }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    button1.Focus();
                return;
            }
            e.Handled = true;





        }

       
    }
}
