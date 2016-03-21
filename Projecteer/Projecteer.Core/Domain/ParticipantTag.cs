using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class ParticipantTag
    {
        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }
        public int TagId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjecteerUser ProjecteerUser { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
