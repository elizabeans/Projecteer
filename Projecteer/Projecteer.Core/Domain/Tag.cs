using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Tag
    {
        public int TagId { get; set; }
        public TagTypes TagTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection <ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<UserTag> UserTags { get; set; }
    }
}
