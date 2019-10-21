namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "roleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleId" });
            AlterColumn("dbo.Users", "roleId", c => c.Int());
            CreateIndex("dbo.Users", "roleId");
            AddForeignKey("dbo.Users", "roleId", "dbo.Roles", "roleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleId" });
            AlterColumn("dbo.Users", "roleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "roleId");
            AddForeignKey("dbo.Users", "roleId", "dbo.Roles", "roleId", cascadeDelete: true);
        }
    }
}
