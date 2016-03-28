namespace Projecteer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Project", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Project", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
