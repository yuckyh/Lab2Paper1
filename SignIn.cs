using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1;

public partial class SignIn : Form, ICanInput, IHasParent
{
    public SignIn(Form parentForm)
    {
        InitializeComponent();
        HasParent.ParentForm = parentForm;
        InitInputs();
    }

    private IHasParent HasParent => this;
    private ICanInput CanInput => this;

    public List<Control> Inputs { get; set; }

    public void InitInputs()
    {
        CanInput.Inputs = new List<Control> { tbUserID, tbPassword };
    }

    public bool IsInputValid(Session1Entities entity)
    {
        if (CanInput.IsInputEmpty()) return false;

        var isUserNew = entity.Users
            .Any(user => user.userId == tbUserID.Text.Trim());

        if (!isUserNew)
        {
            MessageBox.Show("The user id is not in our database, please register an account.");
            return false;
        }

        var isCredentialsCorrect = entity.Users
            .Any(user => user.userId == tbUserID.Text.Trim() && user.userPw == tbPassword.Text.Trim());

        if (isCredentialsCorrect) return true;

        MessageBox.Show("Credentials are incorrect.");
        return false;
    }

    public new Form ParentForm { get; set; }

    private void btnBack_Click(object sender, EventArgs e)
    {
        CanInput.ClearInputs();
        HasParent.Back();
    }

    private void btnSignIn_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();
        if (!IsInputValid(entity)) return;

        CanInput.ClearInputs();

        Hide();
        ResourceManagement resourceManagement = new(this);
        resourceManagement.Show();
    }
}