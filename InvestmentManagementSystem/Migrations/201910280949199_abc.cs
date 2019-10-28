namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "location");
        }
    }
}
