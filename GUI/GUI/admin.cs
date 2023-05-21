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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-5TIKJIL;Initial Catalog=flightSystem;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminLogin adminLogin = new adminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminSignup adminSignup = new adminSignup();
            adminSignup.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainMenu form1 = new mainMenu();
            form1.Show();
            this.Hide();
        }
    }
}
