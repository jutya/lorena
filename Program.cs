using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace test_combobox
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (!System.IO.File.Exists("test.db")) SQLiteConnection.CreateFile("test.db");

            SQLiteConnection connection = new SQLiteConnection("Data Source=test.db;Version=3;datetimeformat=CurrentCulture;");
            connection.Open();
            string sql = "CREATE TABLE lorena(id integer primary key AUTOINCREMENT NOT NULL, name TEXT, disc FLOAT, depend INT, comment VARCHAR(124), depend_tree INT, disc1 FLOAT);";
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = sql;
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO lorena (name, disc,depend,comment, depend_tree, disc1) values (\"Миасс\", 4.0, 0, \"test\", 0, 0);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO lorena (name, disc,depend,comment, depend_tree, disc1) values (\"Амелия\", 5.0, 1, \"test\", 1, 4.0);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO lorena (name, disc,depend,comment, depend_tree, disc1) values (\"Тест1\", 2.0, 1, \"test\", 2, 9.0);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO lorena (name, disc,depend,comment, depend_tree, disc1) values (\"Тест2\", 0.0, 1, \"test\", 1, 4.0);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO lorena (name, disc,depend,comment, depend_tree, disc1) values (\"Курган\", 11.0, 0, \"test\", 0, 0);";
            command.ExecuteNonQuery();

            connection.Close();
            
        }
    }
}