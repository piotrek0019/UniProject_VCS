namespace UniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRetUrlToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ReturnUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ReturnUrl");
        }
    }
}
