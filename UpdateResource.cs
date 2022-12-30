using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1;

public partial class UpdateResource : Form, ICanInput, IHasParent, IHasData<Resource>
{
    private const string DefaultResourceType = "Select a Resource Type";

    public UpdateResource(Form parentForm, Resource resource)
    {
        InitializeComponent();
        HasParent.ParentForm = parentForm;
        HasData.Data = resource;
        InitInputs();
    }

    private IHasParent HasParent => this;
    private ICanInput CanInput => this;

    private IHasData<Resource> HasData => this;
    public List<Control> Inputs { get; set; }

    public void InitInputs()
    {
        Inputs = new List<Control> { tbName, chkListBoxSkills, tbQuantity, comboBoxType };

        using Session1Entities entity = new();
        var defaultResourceTypeOption = new[] { DefaultResourceType }.ToList();
        comboBoxType.DataSource = defaultResourceTypeOption
            .Concat(entity.Resource_Type.Select(resourceType => resourceType.resTypeName))
            .ToList();

        chkListBoxSkills.DataSource = entity.Skills
            .Select(skill => skill.skillName)
            .ToList();

        tbName.Text = HasData.Data.resName;
        comboBoxType.SelectedItem = HasData.Data.Resource_Type.resTypeName;
        tbQuantity.Text = HasData.Data.remainingQuantity.ToString();
        HasData.Data.Resource_Allocation
            .ToList()
            .ForEach(allocation =>
            {
                var index = chkListBoxSkills.Items.IndexOf(allocation.Skill.skillName);
                chkListBoxSkills.SetItemChecked(index, true);
            });
    }

    public bool IsInputValid(Session1Entities entity)
    {
        if (CanInput.IsInputEmpty()) return false;

        if (tbName.Text.Trim().Length == 0 || chkListBoxSkills.SelectedItems.Count == 0 ||
            comboBoxType.SelectedValue?.ToString() == DefaultResourceType)
        {
            MessageBox.Show("Please fill in all the inputs.");
            return false;
        }

        if (!entity.Resources.Any(resource => resource.resName == tbName.Text.Trim()))
        {
            MessageBox.Show("Resource has not been created yet. Please create the resource first.");
            return false;
        }

        if (int.Parse(tbQuantity.Text.Trim()) >= 0) return true;

        MessageBox.Show("Quantity has to be positive.");
        return false;
    }

    public Resource Data { get; set; }
    public new Form ParentForm { get; set; }

    private void btnBack_Click(object sender, EventArgs e)
    {
        CanInput.ClearInputs();
        HasParent.Back();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();

        if (!IsInputValid(entity)) return;

        Data = entity.Resources.First(resource => resource.resId == Data.resId);
        Data.resName = tbName.Text.Trim();
        Data.Resource_Type = entity.Resource_Type.FirstOrDefault(type =>
            type.resTypeName == comboBoxType.SelectedValue.ToString());
        Data.remainingQuantity = int.Parse(tbQuantity.Text.Trim());

        entity.Resource_Allocation.RemoveRange(Data.Resource_Allocation
            .Where(allocation => !chkListBoxSkills.CheckedItems
                .Cast<string>()
                .ToHashSet()
                .Contains(allocation.Skill.skillName))
        );

        entity.Resource_Allocation.AddRange(chkListBoxSkills.CheckedItems.Cast<string>()
            .Where(skillName => !Data.Resource_Allocation.Select(allocation => allocation.Skill.skillName)
                .ToHashSet()
                .Contains(skillName))
            .Select(skillName => new Resource_Allocation
            {
                Resource = Data,
                Skill = entity.Skills.FirstOrDefault(skill => skill.skillName == skillName)
            }));

        entity.SaveChanges();

        MessageBox.Show("Resource has been updated successfully.");
        CanInput.ClearInputs();
        HasParent.Back();
        (ParentForm as ResourceManagement)?.UpdateGridView(entity);
    }
}