using System.Windows.Forms;

namespace Lab2Paper1;

public interface IHasParent
{
    private Form ThisForm => this as Form;
    public Form ParentForm { protected get; set; }

    sealed void Back()
    {
        ParentForm.Show();
        ThisForm.Close();
    }
}