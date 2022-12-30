using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Internal;

namespace Lab2Paper1;

public partial class ResourceManagement : Form, ICanInput, IHasParent
{
    private const string DefaultResourceType = "Select a Resource Type";
    private const string DefaultSkillType = "Select a Skill Type";

    public ResourceManagement(Form parentForm)
    {
        InitializeComponent();
        HasParent.ParentForm = parentForm;
        CanInput.InitInputs();
    }

    private AddResource AddResource { get; set; }
    private UpdateResource UpdateResource { get; set; }
    private IHasParent HasParent => this;
    private ICanInput CanInput => this;
    public List<Control> Inputs { get; set; }

    public void InitInputs()
    {
        using Session1Entities entity = new();

        CanInput.Inputs = new List<Control> { comboBoxTypes, comboBoxSkills };

        var defaultSkillTypeOption = new[] { DefaultSkillType }.ToList();
        var defaultResourceTypeOption = new[] { DefaultResourceType }.ToList();

        comboBoxSkills.DataSource = defaultSkillTypeOption
            .Concat(entity.Skills.Select(skill => skill.skillName))
            .ToList();

        comboBoxTypes.DataSource = defaultResourceTypeOption
            .Concat(entity.Resource_Type.Select(resourceType => resourceType.resTypeName))
            .ToList();

        UpdateGridView(entity);
    }

    public new Form ParentForm { get; set; }

    public void UpdateGridView(Session1Entities entity)
    {
        var selectedType = comboBoxTypes.SelectedValue?.ToString();
        var selectedSkill = comboBoxSkills.SelectedValue?.ToString();

        dataGridView.DataSource = entity.Resource_Allocation
            .Where(allocation => selectedType == DefaultResourceType ||
                                 selectedType == allocation.Resource.Resource_Type.resTypeName)
            .Where(allocation => selectedSkill == DefaultSkillType ||
                                 selectedSkill == allocation.Skill.skillName)
            .GroupBy(allocation => allocation.Resource)
            .AsEnumerable()
            .Select(resource => new
            {
                Name = resource.Key.resName,
                Type = resource.Key.Resource_Type.resTypeName,
                Allocated_Skills = resource.Key.Resource_Allocation.Select(allocation => allocation.Skill.skillName)
                    .Join(","),
                NoOfSkills = resource.Count(),
                AvailableQuantity =
                    resource.Key.remainingQuantity == 0 ? "Not available" :
                    resource.Key.remainingQuantity <= 5 ? "Low Stock" :
                    "Sufficient"
            })
            .ToList();
    }

    private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        using Session1Entities entity = new();
        UpdateGridView(entity);
    }

    private void comboBoxSkills_SelectedIndexChanged(object sender, EventArgs e)
    {
        using Session1Entities entity = new();
        UpdateGridView(entity);
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        AddResource = new AddResource(this);
        AddResource.Show();
        Hide();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();
        dynamic selectedRow = dataGridView.CurrentRow?.DataBoundItem;
        var resName = (string)selectedRow?.Name;
        var selectedResource = entity.Resources.FirstOrDefault(resource => resource.resName == resName);

        UpdateResource = new UpdateResource(this, selectedResource);
        UpdateResource.Show();
        Hide();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        using Session1Entities entity = new();
        dynamic selectedRow = dataGridView.CurrentRow?.DataBoundItem;
        var resName = (string)selectedRow?.Name;
        var selectedResource = entity.Resources.First(resource => resource.resName == resName);

        selectedResource.Resource_Allocation
            .ToList()
            .ForEach(allocation => entity.Resource_Allocation.Remove(allocation));

        entity.Resources.Remove(selectedResource);

        entity.SaveChanges();

        UpdateGridView(entity);
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        CanInput.ClearInputs();
        HasParent.Back();
    }
}