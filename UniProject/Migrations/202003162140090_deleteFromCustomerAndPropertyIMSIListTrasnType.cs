namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFromCustomerAndPropertyIMSIListTrasnType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransTypes", "PropertyIMS_Id", "dbo.PropertyIMS");
            DropForeignKey("dbo.TransTypes", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.TransTypes", new[] { "PropertyIMS_Id" });
            DropIndex("dbo.TransTypes", new[] { "Customer_Id" });
            DropColumn("dbo.TransTypes", "PropertyIMS_Id");
            DropColumn("dbo.TransTypes", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransTypes", "Customer_Id", c => c.Int());
            AddColumn("dbo.TransTypes", "PropertyIMS_Id", c => c.Int());
            CreateIndex("dbo.TransTypes", "Customer_Id");
            CreateIndex("dbo.TransTypes", "PropertyIMS_Id");
            AddForeignKey("dbo.TransTypes", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.TransTypes", "PropertyIMS_Id", "dbo.PropertyIMS", "Id");
        }
    }
}
