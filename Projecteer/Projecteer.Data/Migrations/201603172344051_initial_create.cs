namespace Projecteer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        CommentContent = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ProjecteerUserId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ProjecteerUserId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        AcceptedDate = c.DateTime(),
                        RejectedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.ProjecteerUserId })
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ProjecteerUserId);
            
            CreateTable(
                "dbo.ParticipantTag",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.ProjecteerUserId, t.TagId })
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Participant", t => new { t.ProjectId, t.ProjecteerUserId }, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => new { t.ProjectId, t.ProjecteerUserId })
                .Index(t => t.ProjecteerUserId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.ProjecteerUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId, cascadeDelete: true)
                .Index(t => t.ProjecteerUserId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        RequestDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.ProjecteerUserId })
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ProjecteerUserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ProjecteerUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTag",
                c => new
                    {
                        ProjecteerUserId = c.String(nullable: false, maxLength: 128),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjecteerUserId, t.TagId })
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.ProjecteerUser", t => t.ProjecteerUserId, cascadeDelete: true)
                .Index(t => t.ProjecteerUserId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagTypeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.ProjectTag",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.TagId })
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.ProjectPhoto",
                c => new
                    {
                        ProjectPhotoId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Url = c.String(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectPhotoId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ProjectTag", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ProjectPhoto", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Post", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ParticipantTag", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Participant", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ParticipantTag", new[] { "ProjectId", "ProjecteerUserId" }, "dbo.Participant");
            DropForeignKey("dbo.UserTag", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.UserTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.ProjectTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.ParticipantTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Request", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.Post", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.ParticipantTag", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.Participant", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.Message", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.Comment", "ProjecteerUserId", "dbo.ProjecteerUser");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.ProjectPhoto", new[] { "ProjectId" });
            DropIndex("dbo.ProjectTag", new[] { "TagId" });
            DropIndex("dbo.ProjectTag", new[] { "ProjectId" });
            DropIndex("dbo.UserTag", new[] { "TagId" });
            DropIndex("dbo.UserTag", new[] { "ProjecteerUserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Request", new[] { "ProjecteerUserId" });
            DropIndex("dbo.Request", new[] { "ProjectId" });
            DropIndex("dbo.Message", new[] { "ProjecteerUserId" });
            DropIndex("dbo.ParticipantTag", new[] { "TagId" });
            DropIndex("dbo.ParticipantTag", new[] { "ProjecteerUserId" });
            DropIndex("dbo.ParticipantTag", new[] { "ProjectId", "ProjecteerUserId" });
            DropIndex("dbo.Participant", new[] { "ProjecteerUserId" });
            DropIndex("dbo.Participant", new[] { "ProjectId" });
            DropIndex("dbo.Post", new[] { "ProjecteerUserId" });
            DropIndex("dbo.Post", new[] { "ProjectId" });
            DropIndex("dbo.Comment", new[] { "ProjecteerUserId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropTable("dbo.ProjectPhoto");
            DropTable("dbo.ProjectTag");
            DropTable("dbo.Tag");
            DropTable("dbo.UserTag");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.Request");
            DropTable("dbo.Message");
            DropTable("dbo.ProjecteerUser");
            DropTable("dbo.ParticipantTag");
            DropTable("dbo.Participant");
            DropTable("dbo.Project");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
