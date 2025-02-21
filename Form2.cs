using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogDesktop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private const string ConnectionString = "Server=localhost;Database=blog;Uid=root;Password=;SslMode=None";
        private string AddNexBlogger(string username, string email, string password)
        {
            try
            {
                string sql = "INSERT INTO `usertable`(`UserName`, `Email`, `Password`) VALUES (@username,@email,@password)";

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@email",email);
                        command.Parameters.AddWithValue("@password", password);

                        command.ExecuteNonQuery();
                    }
                   
                    connection.Close();
                    this.Close();
                    return "Sikeres regisztráció.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AddNexBlogger(textBox1.Text,textBox2.Text,textBox3.Text));
        }
    }
}
