using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Models
{
    public class ProjectPhotosModel
    {
        public int ProjectPhotoId { get; set; }
        public int ProjectId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
    }
}
