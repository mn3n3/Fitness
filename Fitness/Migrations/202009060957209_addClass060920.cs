namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClass060920 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        TeleFax = c.String(),
                        ArabicAddress = c.String(),
                        EnglishAddress = c.String(),
                        LogoPath = c.String(),
                        DecimalPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.CustomerCompanies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        CompanyCode = c.Int(nullable: false),
                        CompanyName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.CompanyCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        GroupCode = c.Int(nullable: false),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        Suspension = c.Boolean(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.GroupCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(),
                        ItemName = c.String(),
                        ItemPrice = c.Double(nullable: false),
                        ItemCost = c.Double(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                        Company_CompanyID = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyID)
                .Index(t => t.Company_CompanyID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        JobCode = c.Int(nullable: false),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.JobCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        NationalityCode = c.Int(nullable: false),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.NationalityCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.PlaceOfBirths",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        PlaceCode = c.Int(nullable: false),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.PlaceCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        SourceCode = c.Int(nullable: false),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.SourceCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        TrainerCode = c.Int(nullable: false),
                        TrainerName = c.String(),
                        Suspension = c.Boolean(nullable: false),
                        Percentage = c.Double(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.TrainerCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Sources", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.PlaceOfBirths", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Nationalities", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Items", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Groups", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.CustomerCompanies", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Trainers", new[] { "CompanyID" });
            DropIndex("dbo.Sources", new[] { "CompanyID" });
            DropIndex("dbo.PlaceOfBirths", new[] { "CompanyID" });
            DropIndex("dbo.Nationalities", new[] { "CompanyID" });
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropIndex("dbo.Items", new[] { "Company_CompanyID" });
            DropIndex("dbo.Groups", new[] { "CompanyID" });
            DropIndex("dbo.CustomerCompanies", new[] { "CompanyID" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Sources");
            DropTable("dbo.PlaceOfBirths");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Jobs");
            DropTable("dbo.Items");
            DropTable("dbo.Groups");
            DropTable("dbo.CustomerCompanies");
            DropTable("dbo.Companies");
        }
    }
}
