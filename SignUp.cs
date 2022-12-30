using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1;

public partial class SignUp : Form, ICanInput, IHasParent
{
    private const string DefaultUserType = "Select a user type";

    public SignUp(Form parentForm)
    {
        InitializeComponent();
        HasParent.ParentForm = parentForm;
        CanInput.InitInputs();
    }

    private IHasParent HasParent => this;
    private ICanInput CanInput => this;
    public List<Control> Inputs { get; set; }

    public void InitInputs()
    {
        Inputs = new List<Control> { tbUserID, tbUsername, tbPassword, tbConfirmPassword, comboBoxUserType };

        using Session1Entities entity = new();
        var userTypeNames = entity.User_Type
            .Select(userTypes => userTypes.userTypeName)
            .ToList();

        var defaultUserTypeOption = new[] { DefaultUserType }.ToList();

        comboBoxUserType.DataSource =
            defaultUserTypeOption.Concat(userTypeNames).ToList();
    }

    public bool IsInputValid(Session1Entities entity)
    {
        if (CanInput.IsInputEmpty()) return false;

        // Check if user id length is greater than 8 chars
        if (tbUserID.Text.Trim().Length < 8)
        {
            MessageBox.Show("User ID must contain at least 8 chars.");
            return false;
        }

        // Check if password confirmation matches
        if (tbPassword.Text.Trim() != tbConfirmPassword.Text.Trim())
        {
            MessageBox.Show("Passwords do not match.");
            return false;
        }

        // Check for duplicate user id
        var anyDuplicates = entity.Users.Any(user => user.userId == tbUserID.Text.Trim());
        if (!anyDuplicates) return true;

        MessageBox.Show("User ID has been used. Please use a different user ID to sign up.");
        return false;
    }

    public new Form ParentForm { get; set; }

    private void btnBack_Click(object sender, EventArgs e)
    {
        CanInput.ClearInputs();
        HasParent.Back();
    }


    private void btnSignUp_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();
        // Validate input
        if (!IsInputValid(entity)) return;

        var userTypeId = entity.User_Type
            .Where(userType => userType.userTypeName == comboBoxUserType.SelectedValue.ToString())
            .Select(userType => userType.userTypeId)
            .FirstOrDefault();

        entity.Users.Add(new User
        {
            userId = tbUserID.Text.Trim(),
            userName = tbUsername.Text.Trim(),
            userPw = tbPassword.Text.Trim(),
            userTypeIdFK = userTypeId
        });

        entity.SaveChanges();

        MessageBox.Show($"User {tbUserID.Text.Trim()} has succesfully registered.");

        CanInput.ClearInputs();
        HasParent.Back();
    }
}