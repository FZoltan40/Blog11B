using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                        UserId.Id = dr.GetInt32(0);
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

        public static class UserId
        {
            public static int Id { get; set; }
        }
    }
}
