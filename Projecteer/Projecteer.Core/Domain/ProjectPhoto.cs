using Projecteer.Core.Models;

namespace Projecteer.Core.Domain
{
    public class ProjectPhoto
    {
        public ProjectPhoto()
        {

        }

        public ProjectPhoto(ProjectPhotosModel photo)
        {
            this.Update(photo);
        }

        public void Update(ProjectPhotosModel photo)
        {
            Url = photo.Url;
            FileName = photo.FileName;
        }

        public int ProjectPhotoId { get; set; }
        public int ProjectId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }

        public virtual Project Project { get; set; }
    }
}
