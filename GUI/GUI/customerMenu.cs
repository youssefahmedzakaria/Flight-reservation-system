using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class customerMenu : Form
    {
        public customerMenu()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void customerMenu_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = GetDataFromDatabase();

            dataGridView1.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookFlight bookFlight = new BookFlight();
            bookFlight.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CancelFlight cancelFlightForm = new CancelFlight();
            cancelFlightForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private DataTable GetDataFromDatabase()
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = "SELECT FLIGHT_ID, DURATION, DESTINATION, ARR_TIMESTAMP, DEP_TIMESTAMP, FLIGHT_NO, SOURCE FROM FLIGHT";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(data);
                }
            }

            return data;
        }
    }
}
