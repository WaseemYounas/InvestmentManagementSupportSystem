namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "address", c => c.String());
            AddColumn("dbo.Appointments", "city", c => c.String());
            AddColumn("dbo.Appointments", "country", c => c.String());
            DropColumn("dbo.Appointments", "location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "location", c => c.String());
            DropColumn("dbo.Appointments", "country");
            DropColumn("dbo.Appointments", "city");
            DropColumn("dbo.Appointments", "address");
        }
    }
}
