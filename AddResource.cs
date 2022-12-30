using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1;

public partial class AddResource : Form, ICanInput, IHasParent
{
    private const string DefaultResourceType = "Select a Resource Type";

    public AddResource(Form parentForm)
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
        using Session1Entities entity = new();
        var defaultResourceTypeOption = new[] { DefaultResourceType }.ToList();
        comboBoxType.DataSource = defaultResourceTypeOption
            .Concat(entity.Resource_Type.Select(resourceType => resourceType.resTypeName))
            .ToList();

        chkListBoxSkills.DataSource = entity.Skills
            .Select(skill => skill.skillName)
            .ToList();

        Inputs = new List<Control> { tbName, comboBoxType, tbQuantity, chkListBoxSkills };
    }

    public bool IsInputValid(Session1Entities entity)
    {
        if (CanInput.IsInputEmpty()) return false;

        if (entity.Resources.Any(resource => resource.resName == tbName.Text.Trim()))
        {
            MessageBox.Show("Resource has been created previously, please update it instead.");
            return false;
        }

        if (int.Parse(tbQuantity.Text.Trim()) >= 0) return true;

        MessageBox.Show("Quantity has to be positive.");
        return false;
    }

    public new Form ParentForm { get; set; }

    private void btnBack_Click(object sender, EventArgs e)
    {
        CanInput.ClearInputs();
        HasParent.Back();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();

        if (!IsInputValid(entity)) return;

        entity.Resources.Add(new Resource
        {
            remainingQuantity = int.Parse(tbQuantity.Text.Trim()),
            Resource_Type =
                entity.Resource_Type.First(type => type.resTypeName == comboBoxType.SelectedValue.ToString()),
            resName = tbName.Text.Trim(),
            Resource_Allocation = chkListBoxSkills.CheckedItems
                .Cast<string>()
                .Select(skillName => new Resource_Allocation
                    { Skill = entity.Skills.First(skill => skill.skillName == skillName) })
                .ToList()
        });

        entity.SaveChanges();

        CanInput.ClearInputs();
        HasParent.Back();
        (ParentForm as ResourceManagement)?.UpdateGridView(entity);
    }
}