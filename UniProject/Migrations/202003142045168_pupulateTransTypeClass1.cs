namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pupulateTransTypeClass1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TransTypes (Name) VALUES ('Purchase')");
            Sql("INSERT INTO TransTypes (Name) VALUES ('Sale')");
            Sql("INSERT INTO TransTypes (Name) VALUES ('Rent By')");
            Sql("INSERT INTO TransTypes (Name) VALUES ('Rent To')");
        }
        
        public override void Down()
        {
        }
    }
}
