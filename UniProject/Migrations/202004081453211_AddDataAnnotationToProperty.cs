namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationToProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "Title", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Properties", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Properties", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "Price", c => c.Double());
            AlterColumn("dbo.Properties", "City", c => c.String());
            AlterColumn("dbo.Properties", "Title", c => c.String());
        }
    }
}
