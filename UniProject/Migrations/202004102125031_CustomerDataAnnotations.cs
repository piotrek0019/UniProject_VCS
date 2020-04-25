namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Customers", "Adress", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "PostCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "PostCode", c => c.String());
            AlterColumn("dbo.Customers", "Adress", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
