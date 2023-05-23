using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace GUI
{
    public partial class BookFlight : Form
    {

        public BookFlight()
        {
            InitializeComponent();
        }

        private void BookFlight_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FlightId = validation.IsValidId("Flight ",textBox1.Text);

            string flightClass = validation.IsValidString("Class ", textBox2.Text);

            string PassNo = validation.IsValidPassportNumber(textBox3.Text);
            if (string.IsNullOrWhiteSpace(FlightId))
            {
                textBox1.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(flightClass))
            {
                textBox2.Focus();
                return; // Exit the method
            }

            if (string.IsNullOrWhiteSpace(PassNo))
            {
                textBox3.Focus();
                return; // Exit the method
            }

             Random random = new Random();
            int TicketNo = random.Next(10000000, 99999999);

            int Seatnum = random.Next(1, 100);
            string Seat = Seatnum.ToString();

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Check if the flight exists
                string checkFlightQuery = "SELECT COUNT(*) FROM FLIGHT WHERE FLIGHT_ID = @FlightId";
                SqlCommand checkFlightCommand = new SqlCommand(checkFlightQuery, connection);
                checkFlightCommand.Parameters.AddWithValue("@FlightId", FlightId);

                int flightCount = (int)checkFlightCommand.ExecuteScalar();
                if (flightCount == 0)
                {
                    MessageBox.Show("Flight not found. Please enter a valid Flight ID.");
                    return;
                }

                // Check if the TRANSACTION already exists in the TICKET or PAYMENT tables
                string checkTransactionQuery = "SELECT COUNT(*) FROM TICKET WHERE [TRANSACTION] = 'cash' OR EXISTS " +
                                               "(SELECT 1 FROM PAYMENT WHERE [TRANSACTION] = 'cash')";
                SqlCommand checkTransactionCommand = new SqlCommand(checkTransactionQuery, connection);

                int transactionCount = (int)checkTransactionCommand.ExecuteScalar();
                if (transactionCount < 0)
                {
                    MessageBox.Show("Method don't exist. Please try again later.");
                    return;
                }

                string insertQuery = "INSERT INTO TICKET (TICKET_NO, PASS_NO, FLIGHT_ID, SEAT, CLASS, [TRANSACTION]) " +
                                     "VALUES (@TicketNo, @PassNo, @FlightId, @Seat, @Class, 'cash')";

                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Set parameter values
                command.Parameters.AddWithValue("@TicketNo", TicketNo);
                command.Parameters.AddWithValue("@PassNo", PassNo);
                command.Parameters.AddWithValue("@FlightId", FlightId);
                command.Parameters.AddWithValue("@Seat", Seat);
                command.Parameters.AddWithValue("@Class", flightClass);

                int rowsAffected = command.ExecuteNonQuery();

                MessageBox.Show("Successfully reserved ticket\n" +
                                $"Ticket Number: {TicketNo}\n" +
                                $"Seat Number: {Seat}\n" +
                                $"Flight ID: {FlightId}\n" +
                                $"Flight Class: {flightClass}\n" +
                                $"Payment method: Cash\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerMenu customerMenu = new customerMenu();
            customerMenu.Show();
            this.Hide();
        }
    }
}
