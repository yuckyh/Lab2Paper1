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
        string userName;
        string userId;
        string password;
        string confirm;
        string userTypeName;

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
            
            using (var entity = new Session1Entities())
            {
                // Validate input
                if (!IsValidInput(entity)) return;

                var userTypeId = entity.User_Type
                    .Where(userType => userType.userTypeName == userTypeName)
                    .Select(userType => userType.userTypeId)
                    .FirstOrDefault();

                entity.Users.Add(new User
                {
                    userId = userId,
                    userName = userName,
                    userPw = password,
                    userTypeIdFK = userTypeId
                });

                entity.SaveChanges();

                MessageBox.Show($"User {userId} has succesfully registered.");
                
                HasParent.Back();
            }
        }

        public void InitInputs()
        {
            using (var entity = new Session1Entities())
            {
                var userTypeNames = entity.User_Type
                    .Select(userTypes => userTypes.userTypeName)
                    .ToList();

                comboBoxUserType.DataSource =
                    (new string[] { "Select a user type" }.ToList()).Concat(userTypeNames).ToList();
            }
        }

        public void UpdateInputValues()
        {
            userName = tbUsername.Text.Trim();
            userId = tbUserID.Text.Trim();
            password = tbPassword.Text.Trim();
            confirm = tbConfirmPassword.Text.Trim();
            userTypeName = comboBoxUserType.SelectedValue.ToString();
        }
        public bool IsValidInput(Session1Entities entity)
        {
            // Check if there are any empty inputs
            if (userName.Length == 0 || userId.Length == 0 || password.Length == 0 || confirm.Length == 0 || userTypeName == "Select a user type")
            {
                MessageBox.Show("Please fill in all the textboxes.");
                return false;
            }

            // Check if user id length is greater than 8 chars
            if (userId.Length < 8)
            {
                MessageBox.Show("User ID must contain at least 8 chars.");
                return false;
            }

            // Check if password confirmation matches
            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            // Check for duplicate user id
            var anyDuplicates = entity.Users.Any(user => user.userId == userId);
            if (!anyDuplicates) return true;
            
            MessageBox.Show("User ID has been used. Please use a different user ID to sign up.");
            return false;
        }
    }
}
