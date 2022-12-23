using System;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Lab2Paper1
{
    public partial class ResourceManagement : Form
    {
        public ResourceManagement()
        {
            InitializeComponent();
        }

        private void ResourceManagement_Load(object sender, EventArgs e)
        {
            using (var entity = new Session1Entities())
            {
                var skillsQuery = from skills in entity.Skills select skills.skillName;

                var resourceTypesQuery = from resourceTypes in entity.Resource_Type select resourceTypes.resTypeName;

                comboBoxSkills.DataSource = skillsQuery.ToList();
                comboBoxTypes.DataSource = resourceTypesQuery.ToList();

                dataGridView1.DataSource = entity.Resource_Allocation.GroupBy(resourceAllocation => new {
                    Name = resourceAllocation.Resource.resName,
                    Type = resourceAllocation.Resource.Resource_Type.resTypeName,
                    AvailableQuantity =
                        resourceAllocation.Resource.remainingQuantity == 0 ? "Not available" :
                        resourceAllocation.Resource.remainingQuantity <= 5 ? "Low Stock" :
                        "Sufficient"
                }).AsEnumerable().Select(skillGroup => new
                {
                    skillGroup.Key.Name,
                    skillGroup.Key.Type,
                    Allocated_Skills = skillGroup.Select(group => group.Skill.skillName).Aggregate((current, next) => current + ", " + next),
                    NoOfSkills = skillGroup.Count(),
                }).Where(val => val.Type == comboBoxTypes.SelectedValue).ToList();

                entity.Users.Add(new User());
            }
        }
    }
}
