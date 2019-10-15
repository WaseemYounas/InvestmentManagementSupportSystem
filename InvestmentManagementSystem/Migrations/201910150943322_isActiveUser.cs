namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActiveUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "isActive", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "isActive");
        }
    }
}
