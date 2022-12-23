using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Paper1
{
    public partial class MainMenu : Form
    {
        private SignUp SignUp { get; set; }
        private SignIn SignIn { get; set; }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            Hide();
            SignUp = new SignUp(this);
            SignUp.Show();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            Hide();
            SignIn = new SignIn(this);
            SignIn.Show();
        }
    }
}
