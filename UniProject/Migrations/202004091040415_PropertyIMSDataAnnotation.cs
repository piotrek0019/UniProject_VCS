namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyIMSDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertyIMS", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.PropertyIMS", "Adress", c => c.String(maxLength: 50));
            AlterColumn("dbo.PropertyIMS", "PostCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.PropertyIMS", "City", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyIMS", "City", c => c.String());
            AlterColumn("dbo.PropertyIMS", "PostCode", c => c.String());
            AlterColumn("dbo.PropertyIMS", "Adress", c => c.String());
            AlterColumn("dbo.PropertyIMS", "Name", c => c.String());
        }
    }
}
