using Projecteer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Post
    {
        public Post()
        {

        }

        public Post(PostsModel post)
        {
            this.Update(post);
        }

        public void Update(PostsModel post)
        {
            Title = post.Title;
            Content = post.Content;
            ModifiedDate = DateTime.Now;

        }

        public int PostId { get; set; }
        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        public virtual Project Project { get; set; }
        public virtual ProjecteerUser ProjecteerUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
