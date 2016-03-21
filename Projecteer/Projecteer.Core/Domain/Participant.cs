using Projecteer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Participant
    {
        public Participant()
        {

        }

        public Participant (ParticipantsModel participant)
        {
            this.Update(participant);
        }

        public void Update (ParticipantsModel participant)
        {
            // TODO: potentially add something here
        }

        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }

        public DateTime? AcceptedDate { get; set; }
        public DateTime? RejectedDate { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjecteerUser ProjecteerUser { get; set; }

        public virtual ICollection<ParticipantTag> ParticipantTags { get; set; }

        
    }
}
