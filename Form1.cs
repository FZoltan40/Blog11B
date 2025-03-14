using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BlogDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "zoli007";
            textBox2.Text = "Alma123@";
        }

        private const string ConnectionString = "Server=localhost;Database=blog;Uid=root;Password=;SslMode=None";

        
        private bool beleptet(string username, string password)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT `Id` FROM `usertable` WHERE `UserName` = @username AND `Password`= @password";
                    
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    bool van = dr.Read();
                    if (van)
                    {
                        UsersDatas.Id = dr.GetInt32(0);
                    }
                    connection.Close();
                    return  van;
                }
            }
            catch 
            {
                return false;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (beleptet(textBox1.Text, textBox2.Text))
                {
                    Form3 form2 = new Form3();
                    form2.ShowDialog();
                }
                else
                {
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public static class UsersDatas
        {
            public static int Id { get; set; }
            public static int CategoryId { get; set; }
        }
    }
}
