using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static BlogDesktop.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BlogDesktop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ListComments();
            ListCategory();
        }
        private const string ConnectionString = "Server=localhost;Database=blog;Uid=root;Password=;SslMode=None";
        private bool ListComments()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = 
                    "SELECT blogtable.Post, usertable.UserName FROM usertable RIGHT JOIN blogtable ON usertable.Id = blogtable.UserId;";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) 
                    {
                        var comment = new
                        {
                            Comment = dr.GetString(0),
                            User = dr.GetString(1)
                        }; 
                        listBox1.Items.Add(comment);
                        
                    }
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool ListCategory()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql =
                    "SELECT `CategoryName` FROM `category` ";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var category = new
                        {
                            Name = dr.GetString(0),
                        };
                        comboBox1.Items.Add(category.Name);

                    }
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private string AddNewPost(string title, string post)
        {
            try
            {
                string sql = "INSERT INTO `blogtable`(`Title`, `Post`, `UserId`) VALUES (@title,@post,@userid)";

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@post", post);
                        command.Parameters.AddWithValue("@userid", UserId.Id);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                    listBox1.Items.Clear();
                    ListComments();
                    return "Sikeres post hozzáadás.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string AddNewCategory(string category)
        {
            try
            {
                string sql = "INSERT INTO `category` (`CategoryName`) VALUES (@category)";

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category", category);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                    comboBox1.Items.Clear();
                    ListCategory();
                    return "Sikeres post hozzáadás.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            AddNewPost(textBox1.Text, textBox2.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
               MessageBox.Show(AddNewCategory(textBox1.Text));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
