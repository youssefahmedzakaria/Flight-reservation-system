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
            string flightId = textBox1.Text;
            string aircraftId = textBox2.Text;
            string adminId = textBox3.Text;
            string duration = textBox4.Text;
            string destination = textBox5.Text;
            string arrivalTimestamp = dateTimePicker1.Value.ToString();
            string departureTimestamp = dateTimePicker2.Value.ToString();
            string flightNumber = textBox6.Text;
            string source = textBox7.Text;

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
