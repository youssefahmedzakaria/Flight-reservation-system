﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class updateFlight : Form
    {
        public updateFlight()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void updateFlight_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
            if (flightId == null)
            {
                textBox1.Focus(); 
                return;
            }

            int duration = validation.IsValidDuration(textBox2.Text);
            if (duration <= 0)
            {
                textBox2.Focus(); 
                return; 
            }

            string destination = validation.IsValidString("Destination", textBox3.Text);
            if (destination == null)
            {
                textBox3.Focus();
                return; 
            }

            DateTime arrivalTimestamp = validation.IsValidTimestamp("Arrival", dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss tt"));
            if (arrivalTimestamp == DateTime.MinValue)
            {
                dateTimePicker1.Focus(); 
                return;
            }

            DateTime departureTimestamp = validation.IsValidTimestamp("Departure", dateTimePicker2.Value.ToString("yyyy-MM-dd hh:mm:ss tt"));
            if (departureTimestamp == DateTime.MinValue)
            {
                dateTimePicker2.Focus(); 
                return;
            }

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE FLIGHT SET DURATION = @Duration, DESTINATION = @Destination, ARR_TIMESTAMP = @ArrivalTimestamp, DEP_TIMESTAMP = @DepartureTimestamp WHERE FLIGHT_ID = @FlightId";

                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Set parameter values
                command.Parameters.AddWithValue("@FlightId", flightId);
                command.Parameters.AddWithValue("@Duration", duration);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@ArrivalTimestamp", arrivalTimestamp);
                command.Parameters.AddWithValue("@DepartureTimestamp", departureTimestamp);

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
