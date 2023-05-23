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
            string aircraftId = validation.IsValidId("AirCraft", textBox1.Text);
            string make = validation.IsValidString("Make",textBox2.Text);
            string model = validation.IsValidString("Model", textBox2.Text);
            int maxWeight = validation.IsValidMaxWeight(textBox4.Text);
            int capacity = validation.IsValidCapacity(textBox5.Text);
            if (string.IsNullOrEmpty(aircraftId) || string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model) || maxWeight == 0 || capacity == 0)
            {
                if (string.IsNullOrEmpty(aircraftId))
                    textBox1.Focus();
                else if (string.IsNullOrEmpty(make))
                    textBox2.Focus();
                else if (string.IsNullOrEmpty(model))
                    textBox3.Focus();
                else if (maxWeight == 0)
                    textBox4.Focus();
                else if (capacity == 0)
                    textBox5.Focus();
                return;
            }

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
