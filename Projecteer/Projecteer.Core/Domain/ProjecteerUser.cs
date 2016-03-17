using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using Projecteer.Core.Models;

namespace Projecteer.Core.Domain
{
    public class ProjecteerUser : IUser<string>
    {
        public ProjecteerUser()
        {

        }

        public ProjecteerUser(ProjecteerUsersModel user)
        {
            this.Update(user);
        }

        public void Update(ProjecteerUsersModel user)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participation> Participations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<UserTag> UserTags { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
