using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Report_Paint);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = GetAverageDuration();

            dataGridView1.DataSource = data;
        }

        private DataTable GetAverageDuration()
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = " Select AVG(DURATION) AS AverageDuration from FLIGHT";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(data);
                }
            }
            return data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable data = GetNumberOFCustomers();

            dataGridView1.DataSource = data;
        }

        private DataTable GetNumberOFCustomers()
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = "SELECT COUNT(*) AS NumberOfCustomers FROM Customer";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(data);
                }
            }
            return data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = GetNumberOFFlights();

            dataGridView1.DataSource = data;
        }

        private DataTable GetNumberOFFlights()
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = "SELECT COUNT(*) AS NumberOfFlights FROM Flight";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(data);
                }
            }
            return data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminMenu adminMenu = new adminMenu();  
            adminMenu.Show();
            this.Hide();
        }
        private void Report_Paint(object sender, PaintEventArgs e)
        {
            // Create a linear gradient brush for the background
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCoral, LinearGradientMode.Vertical);

            // Fill the form's background with the gradient brush
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
    }
}
