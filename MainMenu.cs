using System;
using System.Windows.Forms;

namespace Lab2Paper1;

public partial class MainMenu : Form
{
    public MainMenu()
    {
        InitializeComponent();
    }

    private SignUp SignUp { get; set; }
    private SignIn SignIn { get; set; }

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