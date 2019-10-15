namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_imagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "path");
        }
    }
}
