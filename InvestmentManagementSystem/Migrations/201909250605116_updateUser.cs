namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "phone", c => c.String());
            AddColumn("dbo.Users", "address", c => c.String());
            AddColumn("dbo.Users", "city", c => c.String());
            AddColumn("dbo.Users", "country", c => c.String());
            AddColumn("dbo.Users", "gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "gender");
            DropColumn("dbo.Users", "country");
            DropColumn("dbo.Users", "city");
            DropColumn("dbo.Users", "address");
            DropColumn("dbo.Users", "phone");
        }
    }
}
