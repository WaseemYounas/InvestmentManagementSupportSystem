namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "name", c => c.String());
            DropColumn("dbo.Users", "firstName");
            DropColumn("dbo.Users", "lastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "lastName", c => c.String());
            AddColumn("dbo.Users", "firstName", c => c.String());
            DropColumn("dbo.Users", "name");
        }
    }
}
