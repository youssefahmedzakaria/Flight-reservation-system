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
            validation validation = new validation();
            string firstName = validation.IsValidName("First ", textBox1.Text);
            string lastName = validation.IsValidName("Last ", textBox2.Text);
            string userName = validation.IsValidName("User ", textBox3.Text);
            string email = validation.IsValidEmail(textBox4.Text);
            string phoneNum = validation.IsValidPhoneNum(textBox5.Text);
            string gender = textBox6.Text; // No need to validate again as it's a free text input
            int age = validation.IsValidAge(textBox7.Text);
            string passNum = validation.IsValidString("Passport Number", textBox9.Text);
            string dobString = validation.IsValidDateOfBirth(textBox8.Text);

            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNum) ||
                string.IsNullOrEmpty(gender) ||
                age == 0 ||
                string.IsNullOrEmpty(dobString) ||
                string.IsNullOrEmpty(passNum))
            {
                // Set focus to the respective text box
                if (string.IsNullOrEmpty(firstName))
                    textBox1.Focus();
                else if (string.IsNullOrEmpty(lastName))
                    textBox2.Focus();
                else if (string.IsNullOrEmpty(userName))
                    textBox3.Focus();
                else if (string.IsNullOrEmpty(email))
                    textBox4.Focus();
                else if (string.IsNullOrEmpty(phoneNum))
                    textBox5.Focus();
                else if (string.IsNullOrEmpty(gender))
                    textBox6.Focus();
                else if (age == 0)
                    textBox7.Focus();
                else if (string.IsNullOrEmpty(dobString))
                    textBox8.Focus();
                else if (string.IsNullOrEmpty(passNum))
                    textBox9.Focus();

                return;
            }

            if (!DateTime.TryParse(dobString, out DateTime dob))
            {
                MessageBox.Show("Invalid date of birth format. Please enter a valid date.");
                return;
            }

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = "INSERT INTO CUSTOMER (PASS_NO, GENDER, DOB, AGE, PHONE_NO, EMAIL, F_NAME, L_NAME, USERNAME)" +
                                  " VALUES (@passNum, @gender, @dob, @age, @phoneNum, @email, @firstName, @lastName, @userName)";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@passNum", passNum);
                    sqlCommand.Parameters.AddWithValue("@gender", gender);
                    sqlCommand.Parameters.AddWithValue("@dob", dob);
                    sqlCommand.Parameters.AddWithValue("@age", age);
                    sqlCommand.Parameters.AddWithValue("@phoneNum", phoneNum);
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                    sqlCommand.Parameters.AddWithValue("@userName", userName);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Register Done Successfully!");
                    customerMenu customerMenu = new customerMenu();
                    customerMenu.Show();
                    this.Hide();
                }
            }
        }

    }
}