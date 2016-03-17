using Projecteer.Core.Models;
using System;

namespace Projecteer.Core.Domain
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(CommentsModel comment)
        {
            this.Update(comment);
        }

        public void Update(CommentsModel comment)
        {
            CommentContent = comment.CommentContent;
            ModifiedDate = DateTime.Now;
        }

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string ProjecteerUserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual ProjecteerUser ProjecteerUser { get; set; }

    }
}
