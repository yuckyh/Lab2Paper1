using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1
{
    public partial class ResourceManagement : Form, IHasInput
    {
        private const string DefaultResourceType = "Select a Resource Type";
        private const string DefaultSkillType = "Select a Skill Type";
        private string _resourceType, _skillType;

        public ResourceManagement(Form parentForm)
        {
            InitializeComponent();
            HasParent = new HasParent(parentForm, this);
            InitInputs();
        }

        private AddResource AddResource { get; set; }
        public HasParent HasParent { get; }

        public void InitInputs()
        {
            using var entity = new Session1Entities();

            var defaultSkillTypeOption = new string[] { DefaultSkillType }.ToList();
            var defaultResourceTypeOption = new string[] { DefaultResourceType }.ToList();

            comboBoxSkills.DataSource = defaultSkillTypeOption
                .Concat(entity.Skills.Select(skill => skill.skillName))
                .ToList();

            comboBoxTypes.DataSource = defaultResourceTypeOption
                .Concat(entity.Resource_Type.Select(resourceType => resourceType.resTypeName))
                .ToList();

            UpdateGridView(entity);
        }

        public void UpdateInputValues()
        {
            _skillType = (comboBoxSkills.SelectedValue ?? "").ToString();
            _resourceType = (comboBoxTypes.SelectedValue ?? "").ToString();
        }

        public bool IsValidInput(Session1Entities entity)
        {
            return true;
        }

        private void UpdateGridView(Session1Entities entity)
        {
            UpdateInputValues();

            dataGridView1.DataSource = entity.Resource_Allocation
                .GroupBy(resourceAllocation => new
                {
                    Name = resourceAllocation.Resource.resName,
                    Type = resourceAllocation.Resource.Resource_Type.resTypeName,
                    AvailableQuantity =
                        resourceAllocation.Resource.remainingQuantity == 0 ? "Not available" :
                        resourceAllocation.Resource.remainingQuantity <= 5 ? "Low Stock" :
                        "Sufficient"
                })
                .AsEnumerable()
                .Select(skillGroup => new
                {
                    skillGroup.Key.Name,
                    skillGroup.Key.Type,
                    Allocated_Skills = skillGroup.Select(group => group.Skill.skillName)
                        .Aggregate((current, next) => current + ", " + next),
                    NoOfSkills = skillGroup.Count(),
                })
                .Where(val => _resourceType == DefaultResourceType || val.Type == _resourceType)
                .Where(val =>
                    _skillType == DefaultSkillType || val.Allocated_Skills.Split(',').Any(skill => skill == _skillType))
                .ToList();
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var entity = new Session1Entities();
            UpdateGridView(entity);
        }

        private void comboBoxSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var entity = new Session1Entities();
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
            // throw new System.NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HasParent.Back();
        }
    }
}