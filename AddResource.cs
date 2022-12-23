using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1;

public partial class AddResource : Form, IHasInput
{
    private const string DefaultResourceType = "Select a Resource Type";
    private string _name, _resourceType;
    private int _quantity;
    private List<string> _skills;

    public AddResource(Form parentForm)
    {
        InitializeComponent();
        HasParent = new HasParent(parentForm, this);
        InitInputs();
    }

    public HasParent HasParent { get; }

    public void InitInputs()
    {
        using Session1Entities entity = new();
        var defaultResourceTypeOption = new string[] { DefaultResourceType }.ToList();
        comboBoxType.DataSource = defaultResourceTypeOption
            .Concat(entity.Resource_Type.Select(resourceType => resourceType.resTypeName))
            .ToList();

        chkListBoxSkills.DataSource = entity.Skills
            .Select(skill => skill.skillName)
            .ToList();
    }

    public void UpdateInputValues()
    {
        _name = tbName.Text.Trim();
        _quantity = int.Parse(tbQuantity.Text.Trim());
        _skills = new List<string>();
        _resourceType = (comboBoxType.SelectedValue ?? "").ToString();
        foreach (var item in chkListBoxSkills.CheckedItems)
        {
            _skills.Add(item.ToString());
        }
    }

    public bool IsValidInput(Session1Entities entity)
    {
        UpdateInputValues();

        if (_name.Length == 0 || chkListBoxSkills.SelectedItems.Count == 0 || _resourceType == DefaultResourceType)
        {
            MessageBox.Show("Please fill in all the inputs.");
            return false;
        }

        if (_quantity >= 0) return true;

        MessageBox.Show("Quantity has to be positive.");
        return false;
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        HasParent.Back();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();

        if (!IsValidInput(entity)) return;

        entity.Resources.Add(new Resource
        {
            remainingQuantity = _quantity,
            Resource_Type = entity.Resource_Type.FirstOrDefault(type => type.resTypeName == _resourceType),
            resName = _name,
        });

        entity.SaveChanges();

        _skills.ForEach(skillName => entity.Resource_Allocation
            .Add(new Resource_Allocation
            {
                Resource = entity.Resources.FirstOrDefault(resource => resource.resName == _name),
                Skill = entity.Skills.FirstOrDefault(skill => skill.skillName == skillName)
            }));

        entity.SaveChanges();

        MessageBox.Show("Resource has been added and allocated.");
    }
}