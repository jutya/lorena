using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace test_combobox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            //SqlDbType
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length == 0) || (comboBox1.SelectedIndex == -1))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double coint, coint1;
            // String salon;
            double disc = 0, discPr = 0;
            try
            {
                coint = Convert.ToDouble(textBox1.Text);

                int salon = comboBox1.SelectedIndex + 1;
                SQLiteConnection sqlConnection = new SQLiteConnection("Data Source=test.db");
                SQLiteCommand sqlCmd = new SQLiteCommand("SELECT disc, disc1 FROM lorena WHERE id='" + salon + "';", sqlConnection);
                sqlConnection.Open();
                SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    disc = (double)sqlReader["disc"];
                    discPr = (double)sqlReader["disc1"];

                }
                sqlReader.Close();
                sqlConnection.Close();


                coint1 = coint - (coint * (disc + discPr) / 100); // рассчитываем итоговую цену

                label5.Text = coint1.ToString("n"); // выводим данные на форму
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
            if ((textBox1.Text.Length == 0) || (comboBox1.SelectedIndex == -1))
                button1.Enabled = false;
            else
                button1.Enabled = true;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

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



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    } 
}
