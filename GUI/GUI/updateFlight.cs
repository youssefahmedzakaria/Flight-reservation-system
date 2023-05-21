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
    public partial class updateFlight : Form
    {
        public updateFlight()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void updateFlight_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string flightId = textBox1.Text;
            string duration = textBox2.Text;
            string destination = textBox3.Text;
            string arrivalTimestamp = dateTimePicker1.Value.ToString();
            string departureTimestamp = dateTimePicker2.Value.ToString();

            // Perform additional operations or logic using the obtained data

            // Example: Update the data in the database table
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5TIKJIL;Initial Catalog=flightSystem;Integrated Security=True"))
            {
                connection.Open();

                string updateQuery = "UPDATE FLIGHT SET DURATION = @Duration, DESTINATION = @Destination, ARR_TIMESTAMP = @ArrivalTimestamp, DEP_TIMESTAMP = @DepartureTimestamp WHERE FLIGHT_ID = @FlightId";

                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Set parameter values
                command.Parameters.AddWithValue("@FlightId", flightId);
                command.Parameters.AddWithValue("@Duration", duration);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@ArrivalTimestamp", arrivalTimestamp);
                command.Parameters.AddWithValue("@DepartureTimestamp", departureTimestamp);

                // Execute the update query
                int rowsAffected = command.ExecuteNonQuery();

                MessageBox.Show($"{rowsAffected} row(s) updated.");
                adminMenu adminMenu = new adminMenu();
                adminMenu.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminMenu adminMenu = new adminMenu();
            adminMenu.Show();
            this.Hide();
        }
    }
}
