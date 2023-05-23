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
    public partial class addAirCraft : Form
    {
        public addAirCraft()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminMenu adminMenu = new adminMenu();
            adminMenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            validation validation = new validation();
            string aircraftId = validation.IsValidId("Aircraft", textBox1.Text);
            string adminId = validation.IsValidId("Admin", textBox2.Text);
            string airlineName = validation.IsValidString("Airline Name", textBox3.Text);
            string flightId = validation.IsValidId("Flight", textBox4.Text);
            string make = validation.IsValidString("Make", textBox5.Text);
            string model = validation.IsValidString("Model", textBox6.Text);
            int maxWeight = validation.IsValidMaxWeight(textBox7.Text);
            int capacity = validation.IsValidCapacity(textBox8.Text);

            // Check if any of the fields are null or empty
            if (string.IsNullOrWhiteSpace(aircraftId))
            {
                MessageBox.Show("Please enter a valid Aircraft ID.");
                textBox1.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(adminId))
            {
                MessageBox.Show("Please enter a valid Admin ID.");
                textBox2.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(airlineName))
            {
                MessageBox.Show("Please enter a valid Airline Name.");
                textBox3.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(flightId))
            {
                MessageBox.Show("Please enter a valid Flight ID.");
                textBox4.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(make))
            {
                MessageBox.Show("Please enter a valid Make.");
                textBox5.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Please enter a valid Model.");
                textBox6.Focus();
                return; // Exit the method
            }

            if (maxWeight <= 0)
            {
                MessageBox.Show("Please enter a valid Maximum Weight.");
                textBox7.Focus();
                return; // Exit the method
            }

            if (capacity <= 0)
            {
                MessageBox.Show("Please enter a valid Capacity.");
                textBox8.Focus();
                return; // Exit the method
            }

            // Create a connection to the database
            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                // Create a parameterized SQL query
                string sqlQuery = "INSERT INTO AIRCRAFT (CRAFT_ID, ADMIN_ID, AIRLINE_NAME, FLIGHT_ID, MAKE, MODEL, MAX_WEIGHT, CAPACITY)" +
                                  " VALUES (@AircraftId, @AdminId, @AirlineName, @FlightId, @Make, @Model, @MaxWeight, @Capacity)";

                // Create a command with the query and connection
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    // Add parameters and set their values
                    sqlCommand.Parameters.AddWithValue("@AircraftId", aircraftId);
                    sqlCommand.Parameters.AddWithValue("@AdminId", adminId);
                    sqlCommand.Parameters.AddWithValue("@AirlineName", airlineName);
                    sqlCommand.Parameters.AddWithValue("@FlightId", flightId);
                    sqlCommand.Parameters.AddWithValue("@Make", make);
                    sqlCommand.Parameters.AddWithValue("@Model", model);
                    sqlCommand.Parameters.AddWithValue("@MaxWeight", maxWeight);
                    sqlCommand.Parameters.AddWithValue("@Capacity", capacity);

                    // Open the connection and execute the query
                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} row(s) inserted.");
                    adminMenu adminMenu = new adminMenu();
                    adminMenu.Show();
                    this.Hide();
                }
            }
        }
        
    }
}
