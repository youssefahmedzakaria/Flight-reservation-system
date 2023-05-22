using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class customerSignUp : Form
    {
        public customerSignUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.Show();
            this.Hide();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string userName = textBox3.Text;
            string email = textBox4.Text;
            string phoneNum = textBox5.Text;
            string gender = textBox6.Text;
            string age = textBox7.Text;
            string dobString = textBox8.Text;
            string passNum = textBox9.Text;

            // Parse the date of birth string
            if (DateTime.TryParse(dobString, out DateTime dob))
            {
                // Create a connection to the database
                using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
                {
                    // Create a parameterized SQL query
                    string sqlQuery = "INSERT INTO CUSTOMER (PASS_NO, GENDER, DOB, AGE, PHONE_NO, EMAIL, F_NAME, L_NAME, USERNAME)" +
                                      " VALUES (@passNum, @gender, @dob, @age, @phoneNum, @email, @firstName, @lastName, @userName)";

                    // Create a command with the query and connection
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        // Add parameters and set their values
                        sqlCommand.Parameters.AddWithValue("@passNum", passNum);
                        sqlCommand.Parameters.AddWithValue("@gender", gender);
                        sqlCommand.Parameters.AddWithValue("@dob", dob);
                        sqlCommand.Parameters.AddWithValue("@age", age);
                        sqlCommand.Parameters.AddWithValue("@phoneNum", phoneNum);
                        sqlCommand.Parameters.AddWithValue("@email", email);
                        sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                        sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                        sqlCommand.Parameters.AddWithValue("@userName", userName);

                        // Open the connection and execute the query
                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Register Done Succesfully!");
                        customerMenu customerMenu = new customerMenu();
                        customerMenu.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid date of birth format. Please enter a valid date.");
            }
        }

    }
}
