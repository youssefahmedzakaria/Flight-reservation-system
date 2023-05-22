using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class adminMenu : Form
    {
        public adminMenu()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            addAirCraft addAirCraft = new addAirCraft();
            addAirCraft.Show();
            this.Hide();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            updateAirCraft updateAirCraft = new updateAirCraft();   
            updateAirCraft.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addFlight addFlight = new addFlight();
            addFlight.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateFlight updateFlight = new updateFlight(); 
            updateFlight.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails();
            updateCustomerDetails.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
            this.Hide();
        }
    }
}
