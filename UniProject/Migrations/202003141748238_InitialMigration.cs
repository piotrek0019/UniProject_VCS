namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAdress = c.String(),
                        CustomerId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        CustomerId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        PropertyIMSId = c.Int(nullable: false),
                        TransTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyIMS", t => t.PropertyIMSId, cascadeDelete: true)
                .ForeignKey("dbo.TransTypes", t => t.TransTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.PropertyIMSId)
                .Index(t => t.TransTypeId);
            
            CreateTable(
                "dbo.PropertyIMS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PropertyIMS_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyIMS", t => t.PropertyIMS_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.PropertyIMS_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Added = c.DateTime(nullable: false),
                        City = c.String(),
                        Price = c.Double(),
                        NoOfBeds = c.Byte(),
                        RentOrBuy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Added = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SubPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Images", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.TransTypes", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "TransTypeId", "dbo.TransTypes");
            DropForeignKey("dbo.TransTypes", "PropertyIMS_Id", "dbo.PropertyIMS");
            DropForeignKey("dbo.Transactions", "PropertyIMSId", "dbo.PropertyIMS");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Phones", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Phones", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Emails", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Emails", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Services", new[] { "CustomerId" });
            DropIndex("dbo.Images", new[] { "PropertyId" });
            DropIndex("dbo.TransTypes", new[] { "Customer_Id" });
            DropIndex("dbo.TransTypes", new[] { "PropertyIMS_Id" });
            DropIndex("dbo.Transactions", new[] { "TransTypeId" });
            DropIndex("dbo.Transactions", new[] { "PropertyIMSId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Phones", new[] { "StaffId" });
            DropIndex("dbo.Phones", new[] { "CustomerId" });
            DropIndex("dbo.Emails", new[] { "StaffId" });
            DropIndex("dbo.Emails", new[] { "CustomerId" });
            DropTable("dbo.SubPages");
            DropTable("dbo.Services");
            DropTable("dbo.News");
            DropTable("dbo.Properties");
            DropTable("dbo.Images");
            DropTable("dbo.TransTypes");
            DropTable("dbo.PropertyIMS");
            DropTable("dbo.Transactions");
            DropTable("dbo.Phones");
            DropTable("dbo.Staffs");
            DropTable("dbo.Emails");
            DropTable("dbo.Customers");
        }
    }
}
