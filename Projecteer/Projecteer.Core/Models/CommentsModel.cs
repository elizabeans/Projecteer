using System;

namespace Projecteer.Core.Models
{
    public class CommentsModel
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string ProjecteerUserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
