using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Models
{
    public class MessagesModel
    {
        public int MessageId { get; set; }
        public string ProjecteerUserId { get; set; }
        public string Text { get; set; }
    }
}
