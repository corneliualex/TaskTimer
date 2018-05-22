namespace TaskTimer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ActivitiesAndCategories_WithRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Activities", new[] { "ApplicationUserId" });
            DropIndex("dbo.Activities", new[] { "CategoryId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Activities");
        }
    }
}
