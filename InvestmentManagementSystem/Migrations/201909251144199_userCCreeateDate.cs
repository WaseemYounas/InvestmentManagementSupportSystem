namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userCCreeateDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "createdAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "createdAt");
        }
    }
}
