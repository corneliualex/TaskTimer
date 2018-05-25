namespace TaskTimer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Update_RelationShips : DbMigration
    {
        public override void Up()
        {

            Sql("alter table Categories drop constraint DF__Categorie__Activ__5BE2A6F2");
            Sql("alter table Categories drop column ActivityId");
        }

        public override void Down()
        {
        }
    }
}
