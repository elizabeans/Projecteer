using Projecteer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Project
    {
        public Project()
        {

        }

        public Project(ProjectsModel project)
        {
            this.Update(project);
        }

        public void Update(ProjectsModel project)
        {
            ProjectId = project.ProjectId;
            Name = project.Name;
            Description = project.Description;
            ModifiedDate = DateTime.Now;
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<ParticipantTag> ParticipantTags { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ProjectPhoto> ProjectPhotos { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
