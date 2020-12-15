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
            LoadData();
        }
        private void LoadData()
        {
            string connectString = "Data Source=test.db;";

            SQLiteConnection sqlConnection = new SQLiteConnection(connectString);

            sqlConnection.Open();

            string query = "SELECT id, name, disc, depend, comment, depend_tree FROM lorena";

            SQLiteCommand sqlCmd = new SQLiteCommand(query, sqlConnection);

            SQLiteDataReader reader = sqlCmd.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count-1][0] = reader[0].ToString();
                data[data.Count-1][1] = reader[1].ToString();
                data[data.Count-1][2] = reader[2].ToString();
                data[data.Count-1][3] = reader[3].ToString();
                data[data.Count-1][4] = reader[4].ToString();
                data[data.Count-1][5] = reader[5].ToString();
            }

            reader.Close();

            sqlConnection.Close();

             foreach (string[] s in data)
             dataGridView1.Rows.Add(s);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length == 0) || (comboBox1.SelectedIndex == -1))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

       
        public void button1_Click(object sender, EventArgs e)
        {
            double coint, coint1;
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

       
    }
    
}
