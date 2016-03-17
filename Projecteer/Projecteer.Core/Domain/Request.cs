using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Request
    {
        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjecteerUser ProjecteerUser { get; set; }
    }
}
