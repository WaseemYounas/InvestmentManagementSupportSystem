namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_attr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "firstLogin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "firstLogin");
        }
    }
}
