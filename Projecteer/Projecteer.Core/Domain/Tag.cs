using Projecteer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Tag
    {
        public Tag()
        {

        }

        public Tag(TagsModel tag)
        {
            this.Update(tag);
        }

        public void Update(TagsModel tag)
        {
            TagId = tag.TagId;
            TagTypeId = tag.TagTypeId;
            Name = tag.Name;
        }

        public int TagId { get; set; }
        public TagTypes TagTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ParticipantTag> ParticipantTags { get; set; }
        public virtual ICollection <ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<UserTag> UserTags { get; set; }
    }
}
