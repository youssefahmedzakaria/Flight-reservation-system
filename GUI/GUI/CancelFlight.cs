using System;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI
{
    public partial class CancelFlight : Form
    {
        public CancelFlight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write("Enter the Ticket Number: ");
            int ticketNumber = validation.IsValidFlightNumber(textBox1.Text);

            if (ticketNumber == 0)
            {
                textBox1.Focus();
                return;
            }

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Check if the ticket exists
                string checkTicketQuery = "SELECT COUNT(*) FROM TICKET WHERE TICKET_NO = @ticketNumber";
                SqlCommand checkTicketCommand = new SqlCommand(checkTicketQuery, connection);
                checkTicketCommand.Parameters.AddWithValue("@ticketNumber", ticketNumber);

                int ticketCount = (int)checkTicketCommand.ExecuteScalar();
                if (ticketCount == 0)
                {
                    MessageBox.Show("Ticket not found. Please enter a valid Ticket Number.");
                    return;
                }

                // Delete the ticket
                string deleteQuery = "DELETE FROM TICKET WHERE TICKET_NO = @ticketNumber";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@ticketNumber", ticketNumber);

                int rowsAffected = deleteCommand.ExecuteNonQuery();
                MessageBox.Show($"Ticket cancelled");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerMenu customerMenu = new customerMenu();
            customerMenu.Show();
            this.Close();
        }
    }
}
