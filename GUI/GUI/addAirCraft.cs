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
            string aircraftId = textBox1.Text;
            string adminId = textBox2.Text;
            string airlineName = textBox3.Text;
            string flightId = textBox4.Text;
            string make = textBox5.Text;
            string model = textBox6.Text;
            string maxWeight = textBox7.Text;
            string capacity = textBox8.Text;

            // Create a connection to the database
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-5TIKJIL;Initial Catalog=flightSystem;Integrated Security=True"))
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
