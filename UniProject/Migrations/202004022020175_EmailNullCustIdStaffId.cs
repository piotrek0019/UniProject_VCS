namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailNullCustIdStaffId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emails", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Emails", "StaffId", "dbo.Staffs");
            DropIndex("dbo.Emails", new[] { "CustomerId" });
            DropIndex("dbo.Emails", new[] { "StaffId" });
            AlterColumn("dbo.Emails", "CustomerId", c => c.Int());
            AlterColumn("dbo.Emails", "StaffId", c => c.Int());
            CreateIndex("dbo.Emails", "CustomerId");
            CreateIndex("dbo.Emails", "StaffId");
            AddForeignKey("dbo.Emails", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.Emails", "StaffId", "dbo.Staffs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Emails", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Emails", new[] { "StaffId" });
            DropIndex("dbo.Emails", new[] { "CustomerId" });
            AlterColumn("dbo.Emails", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.Emails", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Emails", "StaffId");
            CreateIndex("dbo.Emails", "CustomerId");
            AddForeignKey("dbo.Emails", "StaffId", "dbo.Staffs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Emails", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
