namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClass060920nagham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        SubscriberCode = c.Int(nullable: false),
                        SubscriberType = c.Int(nullable: false),
                        CardNumber = c.String(),
                        SubscriberName = c.String(),
                        BirthDateInt = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Weight = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        Address = c.String(),
                        GenderCode = c.Int(nullable: false),
                        NationalityCode = c.Int(nullable: false),
                        SourceCode = c.Int(nullable: false),
                        JobCode = c.Int(nullable: false),
                        CompanyName = c.Int(nullable: false),
                        CompanyAddress = c.String(),
                        Email = c.String(),
                        SocialStatus = c.String(),
                        PlaceOfBirth = c.String(),
                        IDNumber = c.String(),
                        Type = c.Int(nullable: false),
                        ParentsName = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.SubscriberCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        SubscriptionCode = c.Int(nullable: false),
                        SubscriptionName = c.Int(nullable: false),
                        PeriodByMonth = c.Int(nullable: false),
                        PeriodByDay = c.Int(nullable: false),
                        PeriodByWeeks = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Group = c.String(),
                        Type = c.Int(nullable: false),
                        Classes = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        CostCenterNumber = c.Int(nullable: false),
                        Free = c.Boolean(nullable: false),
                        AddByAdmin = c.Boolean(nullable: false),
                        Stop = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.SubscriptionCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        VisitorCode = c.Int(nullable: false),
                        VisitorName = c.String(),
                        BirthDateInt = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone1 = c.String(),
                        Address = c.String(),
                        GenderCode = c.Int(nullable: false),
                        NationalityCode = c.Int(nullable: false),
                        SourceCode = c.Int(nullable: false),
                        JobCode = c.Int(nullable: false),
                        Note = c.String(),
                        Interseted = c.Boolean(nullable: false),
                        UnInterseted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.VisitorCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitors", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Subscriptions", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Subscribers", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Visitors", new[] { "CompanyID" });
            DropIndex("dbo.Subscriptions", new[] { "CompanyID" });
            DropIndex("dbo.Subscribers", new[] { "CompanyID" });
            DropTable("dbo.Visitors");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Subscribers");
        }
    }
}
