using System.Windows.Forms;

namespace Lab2Paper1
{
    public class HasParent
    {
        private Form ParentForm { get; }
        private Form ThisForm { get; }
        public HasParent(Form parentForm, Form thisForm)
        {
            ParentForm = parentForm;
            ThisForm = thisForm;
        }

        public void Back()
        {
            ParentForm.Show();
            ThisForm.Close();
        }
    }
}