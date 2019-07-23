namespace Lottery.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        LotteryEventId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LotteryEvents", t => t.LotteryEventId)
                .Index(t => t.LotteryEventId);
            
            CreateTable(
                "dbo.LotteryEvents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        CardPrice = c.Int(nullable: false),
                        WinnerCardId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "LotteryEventId", "dbo.LotteryEvents");
            DropIndex("dbo.Cards", new[] { "LotteryEventId" });
            DropTable("dbo.LotteryEvents");
            DropTable("dbo.Cards");
        }
    }
}
