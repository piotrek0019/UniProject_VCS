namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePropertyIMSClassWithDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyIMS", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyIMS", "Description");
        }
    }
}
