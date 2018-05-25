namespace TaskTimer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityModel : DbMigration
    {
        public override void Up()
        {
            Sql("alter table Activities drop column Date");
            Sql("alter table Activities drop column TimeSpent");
            AddColumn("dbo.Activities", "Date", c => c.DateTime());
            AddColumn("dbo.Activities", "TimeSpent", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "TimeSpent");
            DropColumn("dbo.Activities", "Date");
        }
    }
}
