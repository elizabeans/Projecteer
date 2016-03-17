using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class ProjectTag
    {
        public int ProjectId { get; set; }
        public int TagId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
