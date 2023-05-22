using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI
{
    public partial class adminLogin : Form
    {
        public adminLogin()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string u = textBox2.Text; // Replace with the username entered by the user
            string password = textBox1.Text; // Replace with the password entered by the user

            if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return; // Exit the method
            }

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM ADMIN WHERE USERNAME = @Username AND PASSWORD = @Password";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Username", u);
                command.Parameters.AddWithValue("@Password", password);

                int matchingRecordsCount = (int)command.ExecuteScalar();

                if (matchingRecordsCount > 0)
                {
                    // Login successful
                    MessageBox.Show("Login successful!");
                    adminMenu adminMenu = new adminMenu();
                    adminMenu.Show();
                    this.Hide();
                    // Add your logic here for successful login, such as navigating to another form
                }
                else
                {
                    // Invalid username or password
                    MessageBox.Show("Invalid username or password. Login failed.");
                    adminLogin adminLogin = new adminLogin();   
                    adminLogin.Show();
                    this.Hide();
                    // Add your logic here for failed login
                }
            }
            this.Hide();
        }

        
    }
}
