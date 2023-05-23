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
    public partial class addFlight : Form
    {
        public addFlight()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
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
            validation validation = new validation();
            string flightId = validation.IsValidId("Flight", textBox1.Text);
            string aircraftId = validation.IsValidId("Aircraft", textBox2.Text);
            string adminId = validation.IsValidId("Admin", textBox3.Text);
            int duration = validation.IsValidDuration(textBox4.Text);
            string destination = validation.IsValidString("Destination", textBox5.Text);
            DateTime arrivalTimestamp = validation.IsValidTimestamp("Arrival", dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss tt"));
            DateTime departureTimestamp = validation.IsValidTimestamp("Departure", dateTimePicker2.Value.ToString("yyyy-MM-dd hh:mm:ss tt"));
            int flightNumber = validation.IsValidFlightNumber(textBox6.Text);
            string source = validation.IsValidString("Source", textBox7.Text);

            // Check if any of the fields are null or empty
            if (string.IsNullOrWhiteSpace(flightId))
            {
                MessageBox.Show("Please enter a valid Flight ID.");
                textBox1.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(aircraftId))
            {
                MessageBox.Show("Please enter a valid Aircraft ID.");
                textBox2.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(adminId))
            {
                MessageBox.Show("Please enter a valid Admin ID.");
                textBox3.Focus();
                return; // Exit the method
            }

            if (duration <= 0)
            {
                MessageBox.Show("Please enter a valid Duration.");
                textBox4.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(destination))
            {
                MessageBox.Show("Please enter a valid Destination.");
                textBox5.Focus();
                return; // Exit the method
            }

            if (arrivalTimestamp == DateTime.MinValue)
            {
                MessageBox.Show("Please enter a valid Arrival Timestamp.");
                dateTimePicker1.Focus();
                return; // Exit the method
            }

            if (departureTimestamp == DateTime.MinValue)
            {
                MessageBox.Show("Please enter a valid Departure Timestamp.");
                dateTimePicker2.Focus();
                return; // Exit the method
            }

            if (flightNumber <= 0)
            {
                MessageBox.Show("Please enter a valid Flight Number.");
                textBox6.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                MessageBox.Show("Please enter a valid Source.");
                textBox7.Focus();
                return; // Exit the method
            }

            // Check if any of the fields are null or empty
            if (string.IsNullOrWhiteSpace(flightId))
            {
                MessageBox.Show("Please enter a valid Flight ID.");
                textBox1.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(aircraftId))
            {
                MessageBox.Show("Please enter a valid Aircraft ID.");
                textBox2.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(adminId))
            {
                MessageBox.Show("Please enter a valid Admin ID.");
                textBox3.Focus();
                return; // Exit the method
            }

            if (duration <= 0)
            {
                MessageBox.Show("Please enter a valid Duration.");
                textBox4.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(destination))
            {
                MessageBox.Show("Please enter a valid Destination.");
                textBox5.Focus();
                return; // Exit the method
            }

            if (arrivalTimestamp == DateTime.MinValue)
            {
                MessageBox.Show("Please enter a valid Arrival Timestamp.");
                dateTimePicker1.Focus();
                return; // Exit the method
            }

            if (departureTimestamp == DateTime.MinValue)
            {
                MessageBox.Show("Please enter a valid Departure Timestamp.");
                dateTimePicker2.Focus();
                return; // Exit the method
            }

            if (flightNumber <= 0 )
            {
                MessageBox.Show("Please enter a valid Flight Number.");
                textBox6.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                MessageBox.Show("Please enter a valid Source.");
                textBox7.Focus();
                return; // Exit the method
            }

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                sqlConnection.Open();

                string insertQuery = "INSERT INTO FLIGHT (FLIGHT_ID, CRAFT_ID, ADMIN_ID, DURATION, DESTINATION, ARR_TIMESTAMP, DEP_TIMESTAMP, FLIGHT_No, SOURCE) " +
                                     "VALUES (@FlightId, @AircraftId, @AdminId, @Duration, @Destination, @ArrivalTimestamp, @DepartureTimestamp, @FlightNumber, @Source)";

                SqlCommand command = new SqlCommand(insertQuery, sqlConnection);

                // Set parameter values
                command.Parameters.AddWithValue("@FlightId", flightId);
                command.Parameters.AddWithValue("@AircraftId", aircraftId);
                command.Parameters.AddWithValue("@AdminId", adminId);
                command.Parameters.AddWithValue("@Duration", duration);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@ArrivalTimestamp", arrivalTimestamp);
                command.Parameters.AddWithValue("@DepartureTimestamp", departureTimestamp);
                command.Parameters.AddWithValue("@FlightNumber", flightNumber);
                command.Parameters.AddWithValue("@Source", source);

                // Execute the insert query
                int rowsAffected = command.ExecuteNonQuery();

                MessageBox.Show($"{rowsAffected} row(s) inserted.");

                // Additional logic or actions
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
