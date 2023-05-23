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

namespace GUI
{
    public partial class UpdateCustomerDetails : Form
    {
        public UpdateCustomerDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PassNum = validation.IsValidPassportNumber(textBox1.Text);
            string PhoneNum = validation.IsValidPhoneNum(textBox2.Text);
            string Email = validation.IsValidString("Email", textBox3.Text);
            string Username = validation.IsValidName("Username", textBox4.Text);

            if (string.IsNullOrEmpty(PassNum) || string.IsNullOrEmpty(PhoneNum) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Username))
            {
                if (string.IsNullOrEmpty(PassNum))
                    textBox1.Focus();
                else if (string.IsNullOrEmpty(PhoneNum))
                    textBox2.Focus();
                else if (string.IsNullOrEmpty(Email))
                    textBox3.Focus();
                else if (string.IsNullOrEmpty(Username))
                    textBox4.Focus();

            }
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE CUSTOMER SET PHONE_NO = @PhoneNum, EMAIL = @Email, USERNAME = @Username WHERE PASS_NO = @PassNum";

                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Set parameter values
                command.Parameters.AddWithValue("@PhoneNum", PhoneNum);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@PassNum", PassNum);

                // Execute the update query
                int rowsAffected = command.ExecuteNonQuery();

                MessageBox.Show("Customer Updated!");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            adminMenu adminMenu = new adminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
