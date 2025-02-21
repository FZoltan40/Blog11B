using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static BlogDesktop.Form1;

namespace BlogDesktop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ListComments();
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
                            User = dr.GetString(1),
                            Id = UserId.Id
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
    }
}
