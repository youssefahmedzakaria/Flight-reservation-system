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
    public partial class updateAirCraft : Form
    {
        public updateAirCraft()
        {
            InitializeComponent();
        }

        private void updateAirCraft_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aircraftId = textBox1.Text;
            string make = textBox2.Text;
            string model = textBox3.Text;
            string maxWeight = textBox4.Text;
            string capacity = textBox5.Text;

            using (SqlConnection sqlConnection = new SqlConnection(Program.connectionString))
            {
                sqlConnection.Open();

                string updateQuery = "UPDATE AIRCRAFT SET MAKE = @make, MODEL = @model, MAX_WEIGHT = @maxWeight, CAPACITY = @capacity WHERE CRAFT_ID = @aircraftId";

                SqlCommand command = new SqlCommand(updateQuery, sqlConnection);

                // Set parameter values
                command.Parameters.AddWithValue("@make", make);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@maxWeight", maxWeight);
                command.Parameters.AddWithValue("@capacity", capacity);
                command.Parameters.AddWithValue("@aircraftId", aircraftId);

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
