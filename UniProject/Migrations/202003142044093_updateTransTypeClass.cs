namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTransTypeClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "TransTypeId", "dbo.TransTypes");
            DropIndex("dbo.Transactions", new[] { "TransTypeId" });
            DropPrimaryKey("dbo.TransTypes");
            AlterColumn("dbo.Transactions", "TransTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.TransTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.TransTypes", "Id");
            CreateIndex("dbo.Transactions", "TransTypeId");
            AddForeignKey("dbo.Transactions", "TransTypeId", "dbo.TransTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransTypeId", "dbo.TransTypes");
            DropIndex("dbo.Transactions", new[] { "TransTypeId" });
            DropPrimaryKey("dbo.TransTypes");
            AlterColumn("dbo.TransTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Transactions", "TransTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TransTypes", "Id");
            CreateIndex("dbo.Transactions", "TransTypeId");
            AddForeignKey("dbo.Transactions", "TransTypeId", "dbo.TransTypes", "Id", cascadeDelete: true);
        }
    }
}
