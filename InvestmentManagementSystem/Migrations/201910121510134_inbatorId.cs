namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inbatorId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ideas", "incubatorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ideas", "incubatorId");
        }
    }
}
