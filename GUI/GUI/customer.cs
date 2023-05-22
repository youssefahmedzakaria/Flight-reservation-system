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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerLogin customerLogin = new customerLogin();
            customerLogin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerSignUp customerSignUp = new customerSignUp();
            customerSignUp.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainMenu MainMenu = new mainMenu();
            MainMenu.Show();
            this.Hide();
        }
    }
}
