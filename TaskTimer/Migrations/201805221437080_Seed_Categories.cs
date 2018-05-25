namespace TaskTimer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_Categories : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Categories(Name) values ('Category1'), ('Category2'), ('Category3')");
        }
        
        public override void Down()
        {
        }
    }
}
