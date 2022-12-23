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
        private string _userId;
        private string _password;
        private ResourceManagement ResourceManagement { get; set; }
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
                if (!IsValidInput(entity)) return;
                
                Hide();
                ResourceManagement = new ResourceManagement(this);
                ResourceManagement.Show();
            }
        }

        public void InitInputs() { }

        public void UpdateInputValues()
        {
            _userId = tbUserID.Text.ToString().Trim();
            _password = tbPassword.Text.ToString().Trim();
        }

        public bool IsValidInput(Session1Entities entity)
        {
            UpdateInputValues();

            if (_userId.Length == 0 || _password.Length == 0)
            {
                MessageBox.Show("Please fill in all the textboxes.");
                return false;
            }
            
            var isUserNew = entity.Users
                .Any(user => user.userId == _userId);
            
            if (!isUserNew)
            {
                MessageBox.Show("The user id is not in our database, please register an account.");
                return false;
            }

            var isCredentialsCorrect = entity.Users
                .Where(user => user.userId == _userId)
                .Select(user => user.userPw)
                .FirstOrDefault() == _password;
            
            if(isCredentialsCorrect) return true;
            
            MessageBox.Show("Credentials are incorrect.");
            return false;
        }
    }
}
