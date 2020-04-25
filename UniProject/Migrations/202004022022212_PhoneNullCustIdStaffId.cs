namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNullCustIdStaffId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Phones", "StaffId", "dbo.Staffs");
            DropIndex("dbo.Phones", new[] { "CustomerId" });
            DropIndex("dbo.Phones", new[] { "StaffId" });
            AlterColumn("dbo.Phones", "CustomerId", c => c.Int());
            AlterColumn("dbo.Phones", "StaffId", c => c.Int());
            CreateIndex("dbo.Phones", "CustomerId");
            CreateIndex("dbo.Phones", "StaffId");
            AddForeignKey("dbo.Phones", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.Phones", "StaffId", "dbo.Staffs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Phones", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Phones", new[] { "StaffId" });
            DropIndex("dbo.Phones", new[] { "CustomerId" });
            AlterColumn("dbo.Phones", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.Phones", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Phones", "StaffId");
            CreateIndex("dbo.Phones", "CustomerId");
            AddForeignKey("dbo.Phones", "StaffId", "dbo.Staffs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Phones", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
