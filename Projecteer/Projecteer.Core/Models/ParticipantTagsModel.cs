using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Models
{
    public class ParticipantTagsModel
    {
        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }
        public int TagId { get; set; }
    }
}
