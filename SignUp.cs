using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Internal;

namespace Lab2Paper1
{
    public partial class SignUp : Form, IHasInput
    {
        private string _userName;
        private string _userId;
        private string _password;
        private string _confirm;
        private string _userTypeName;
        
        private const string DefaultUserType = "Select a user type";

        public HasParent HasParent { get; }

        public SignUp(Form parentForm)
        {
            InitializeComponent();
            HasParent = new HasParent(parentForm, this);
            InitInputs();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HasParent.Back();
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            UpdateInputValues();

            using var entity = new Session1Entities();
            // Validate input
            if (!IsValidInput(entity)) return;

            var userTypeId = entity.User_Type
                .Where(userType => userType.userTypeName == _userTypeName)
                .Select(userType => userType.userTypeId)
                .FirstOrDefault();

            entity.Users.Add(new User
            {
                userId = _userId,
                userName = _userName,
                userPw = _password,
                userTypeIdFK = userTypeId
            });

            entity.SaveChanges();

            MessageBox.Show($"User {_userId} has succesfully registered.");
                
            HasParent.Back();
        }

        public void InitInputs()
        {
            using var entity = new Session1Entities();
            
            var userTypeNames = entity.User_Type
                .Select(userTypes => userTypes.userTypeName)
                .ToList();
                
            var defaultUserTypeOption = new string[] { DefaultUserType }.ToList(); 

            comboBoxUserType.DataSource =
                defaultUserTypeOption.Concat(userTypeNames).ToList();
        }

        public void UpdateInputValues()
        {
            _userName = tbUsername.Text.Trim();
            _userId = tbUserID.Text.Trim();
            _password = tbPassword.Text.Trim();
            _confirm = tbConfirmPassword.Text.Trim();
            _userTypeName = comboBoxUserType.SelectedValue != null ? comboBoxUserType.SelectedValue.ToString() : "";
        }
        public bool IsValidInput(Session1Entities entity)
        {
            // Check if there are any empty inputs
            if (_userName.Length == 0 || _userId.Length == 0 || _password.Length == 0 || _confirm.Length == 0 || _userTypeName == DefaultUserType || _userTypeName == "")
            {
                MessageBox.Show("Please fill in all the textboxes.");
                return false;
            }

            // Check if user id length is greater than 8 chars
            if (_userId.Length < 8)
            {
                MessageBox.Show("User ID must contain at least 8 chars.");
                return false;
            }

            // Check if password confirmation matches
            if (_password != _confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            // Check for duplicate user id
            var anyDuplicates = entity.Users.Any(user => user.userId == _userId);
            if (!anyDuplicates) return true;
            
            MessageBox.Show("User ID has been used. Please use a different user ID to sign up.");
            return false;
        }
    }
}
