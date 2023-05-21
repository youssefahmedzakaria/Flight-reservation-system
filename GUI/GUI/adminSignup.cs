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
            // Get the values from the textboxes
            string adminId = textBox1.Text;
            string role = textBox6.Text;
            string phoneNo = textBox5.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;
            string firstName = textBox2.Text;
            string lastName = textBox8.Text;
            string username = textBox7.Text;

            // Create a connection to the database
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-5TIKJIL;Initial Catalog=flightSystem;Integrated Security=True"))
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
