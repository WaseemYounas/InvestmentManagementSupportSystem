namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        appId = c.Int(nullable: false, identity: true),
                        appDate = c.DateTime(nullable: false),
                        ideaId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        senderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.appId)
                .ForeignKey("dbo.Ideas", t => t.ideaId, cascadeDelete: true)
                .Index(t => t.ideaId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        reqId = c.Int(nullable: false, identity: true),
                        ideaId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        senderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.reqId)
                .ForeignKey("dbo.Ideas", t => t.ideaId, cascadeDelete: true)
                .Index(t => t.ideaId);
            
            AddColumn("dbo.Users", "isActive", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ideaId", "dbo.Ideas");
            DropForeignKey("dbo.Appointments", "ideaId", "dbo.Ideas");
            DropIndex("dbo.Requests", new[] { "ideaId" });
            DropIndex("dbo.Appointments", new[] { "ideaId" });
            DropColumn("dbo.Users", "isActive");
            DropTable("dbo.Requests");
            DropTable("dbo.Appointments");
        }
    }
}
