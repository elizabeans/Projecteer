using Projecteer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Participation
    {
        public Participation()
        {

        }

        public Participation (ParticipationsModel participation)
        {
            this.Update(participation);
        }

        public void Update (ParticipationsModel participation)
        {
            // TODO: potentially add something here
        }

        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjecteerUser ProjecteerUser { get; set; }
    }
}
