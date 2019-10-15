namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        roleId = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                    })
                .PrimaryKey(t => t.roleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        password = c.String(),
                        roleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId)
                .ForeignKey("dbo.Roles", t => t.roleId, cascadeDelete: true)
                .Index(t => t.roleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
