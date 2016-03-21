using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projecteer.Core.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Projecteer.Data.Infrastructure
{
    public class ProjecteerDataContext : DbContext
    {
        public ProjecteerDataContext() : base("Projecteer")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Participant> Participants { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Project> Projects { get; set; }
        public IDbSet<ProjecteerUser> Users { get; set; }
        public IDbSet<ProjectPhoto> ProjectPhotos { get; set; }
        public IDbSet<ProjectTag> ProjectTags { get; set; }
        public IDbSet<Request> Requests { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<UserTag> UserTags { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.Messages)
                .WithRequired(m => m.ProjecteerUser)
                .HasForeignKey(m => m.ProjecteerUserId);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.Comments)
                .WithRequired(c => c.ProjecteerUser)
                .HasForeignKey(c => c.ProjecteerUserId);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.Posts)
                .WithRequired(p => p.ProjecteerUser)
                .HasForeignKey(p => p.ProjecteerUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.Participants)
                .WithRequired(p => p.ProjecteerUser)
                .HasForeignKey(p => p.ProjecteerUserId);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.Requests)
                .WithRequired(r => r.ProjecteerUser)
                .HasForeignKey(r => r.ProjecteerUserId);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.UserTags)
                .WithRequired(u => u.ProjecteerUser)
                .HasForeignKey(u => u.ProjecteerUserId);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(p => p.ParticipantTags)
                .WithRequired(p => p.ProjecteerUser)
                .HasForeignKey(p => p.ProjecteerUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ParticipantTags)
                .WithRequired(p => p.Project)
                .HasForeignKey(p => p.ProjectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Participants)
                .WithRequired(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Posts)
                .WithRequired(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectPhotos)
                .WithRequired(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectTags)
                .WithRequired(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Requests)
                .WithRequired(r => r.Project)
                .HasForeignKey(r => r.ProjectId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithRequired(c => c.Post)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.ProjectTags)
                .WithRequired(p => p.Tag)
                .HasForeignKey(p => p.TagId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.UserTags)
                .WithRequired(u => u.Tag)
                .HasForeignKey(u => u.TagId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.ParticipantTags)
                .WithRequired(p => p.Tag)
                .HasForeignKey(p => p.TagId);

            modelBuilder.Entity<ProjecteerUser>()
                .HasMany(u => u.Roles)
                .WithRequired(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithRequired(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ParticipantTag>()
                .HasKey(pt => new { pt.ProjectId, pt.ProjecteerUserId, pt.TagId});

            modelBuilder.Entity<ProjectTag>()
                .HasKey(pt => new { pt.ProjectId, pt.TagId });

            modelBuilder.Entity<UserTag>()
                .HasKey(ut => new { ut.ProjecteerUserId, ut.TagId });

            modelBuilder.Entity<Request>()
                .HasKey(r => new { r.ProjectId, r.ProjecteerUserId });

            modelBuilder.Entity<Participant>()
                .HasKey(p => new { p.ProjectId, p.ProjecteerUserId });

            modelBuilder.Entity<UserRole>()
                .HasKey(u => new { u.UserId, u.RoleId });
        }
    }
}
