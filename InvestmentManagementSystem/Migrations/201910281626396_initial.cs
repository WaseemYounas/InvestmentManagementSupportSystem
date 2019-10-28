namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "address", c => c.String());
            AddColumn("dbo.Appointments", "city", c => c.String());
            AddColumn("dbo.Appointments", "country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "country");
            DropColumn("dbo.Appointments", "city");
            DropColumn("dbo.Appointments", "address");
        }
    }
}
