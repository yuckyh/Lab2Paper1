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
    public partial class SignIn : Form, IHasInput
    {
        string userID;
        string password;
        public HasParent HasParent { get; }
        public SignIn(Form parentForm)
        {
            InitializeComponent();
            HasParent = new HasParent(parentForm, this);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HasParent.Back();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            using (var entity = new Session1Entities())
            {
                
            }
        }

        public void InitInputs() { }

        public void UpdateInputValues()
        {
            userID = tbUserID.Text.ToString().Trim();
            password = tbPassword.Text.ToString().Trim();
        }

        public bool IsValidInput(Session1Entities entity)
        {
            UpdateInputValues();

            if (userID.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Please fill in all the textboxes.");
                return false;
            }
            
            var doesUserExist = entity.Users
                .Any(user => user.userId == userID);
            
            if (!doesUserExist)
            {
                MessageBox.Show("The user id is not in our database, please register an account.");
                return false;
            }

            var isCredentialsCorrect = entity.Users
                .Where(user => user.userId == userID)
                .Select(user => user.userPw)
                .Any(userPw => userPw == password);
            
            if(isCredentialsCorrect) return true;
            
            MessageBox.Show("Credentials are incorrect.");
            return false;
        }
    }
}
