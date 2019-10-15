namespace InvestmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Idea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ideas",
                c => new
                    {
                        ideaId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ideaId)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ideas", "userId", "dbo.Users");
            DropIndex("dbo.Ideas", new[] { "userId" });
            DropTable("dbo.Ideas");
        }
    }
}
