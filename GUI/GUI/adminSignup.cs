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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class adminSignup : Form
    {
        public adminSignup()
        {
            InitializeComponent();
        }





        private void adminSignup_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminId = validation.IsValidId("Admin", textBox1.Text);
            string role = validation.IsValidRole(textBox6.Text);
            string phoneNo = validation.IsValidPhoneNum(textBox5.Text);
            string email = validation.IsValidEmail(textBox3.Text);
            string password = validation.IsValidPassword(textBox4.Text);
            string firstName = validation.IsValidName("First", textBox2.Text);
            string lastName = validation.IsValidName("Last", textBox8.Text);
            string username = validation.IsValidString("Username", textBox7.Text);

            if (string.IsNullOrEmpty(adminId))
            {
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                textBox6.Focus();
                return;
            }

            if (string.IsNullOrEmpty(phoneNo))
            {
                textBox5.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                textBox3.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                textBox4.Focus();
                return;
            }

            if (string.IsNullOrEmpty(firstName))
            {
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                textBox8.Focus();
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                textBox7.Focus();
                return;
            }
            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                // Create a parameterized SQL query
                string sqlQuery = "INSERT INTO ADMIN (ADMIN_ID, ROLE, PHONE_NO, EMAIL, PASSWORD, F_NAME, L_NAME, USERNAME)" +
                                  " VALUES (@AdminId, @Role, @PhoneNo, @Email, @Password, @FirstName, @LastName, @Username)";

                // Create a command with the query and connection
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    // Add parameters and set their values
                    sqlCommand.Parameters.AddWithValue("@AdminId", adminId);
                    sqlCommand.Parameters.AddWithValue("@Role", role);
                    sqlCommand.Parameters.AddWithValue("@PhoneNo", phoneNo);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                    sqlCommand.Parameters.AddWithValue("@Username", username);

                    // Open the connection and execute the query
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    adminMenu adminMenu = new adminMenu();
                    adminMenu.Show();
                    this.Hide();
                }
            }
        }

    }
}
