using Projecteer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Models
{
    public class TagsModel
    {
        public int TagId { get; set; }
        public TagTypes TagTypeId { get; set; }

        public string Name { get; set; }
    }
}
