using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class ProjectPhoto
    {
        public int ProjectPhotoId { get; set; }
        public int ProjectId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }

        public virtual Project Project { get; set; }
    }
}
