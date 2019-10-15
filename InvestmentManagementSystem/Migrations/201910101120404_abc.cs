namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ideas", "amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ideas", "amount");
        }
    }
}
