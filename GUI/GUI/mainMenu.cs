using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-5TIKJIL;Initial Catalog=flightSystem;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin form2 = new admin();  // Assuming Form2 is the desired form
            form2.Show();
            this.Hide(); // Hide Form1 if you want it to disappear when Form2 is shown
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer form3 = new customer();  // Assuming Form2 is the desired form
            form3.Show();
            this.Hide(); // Hide Form1 if you want it to disappear when Form2 is shown
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}