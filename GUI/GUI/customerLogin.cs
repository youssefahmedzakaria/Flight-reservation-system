using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class customerLogin : Form
    {
        public customerLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = validation.IsValidName("User", textBox1.Text);
            string password = validation.IsValidPassportNumber( textBox2.Text);
            if (string.IsNullOrEmpty(username))
            {
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE USERNAME = @Username AND PASS_NO = @Password";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int matchingRecordsCount = (int)command.ExecuteScalar();

                if (matchingRecordsCount > 0)
                {
                    // Login successful
                    MessageBox.Show("Login successful!");

                    customerMenu CustomerMenu = new customerMenu();
                    CustomerMenu.Show();
                    this.Hide();
                }
                else
                {
                    // Invalid username or password
                    MessageBox.Show("Invalid username or password. Login failed.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
