namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nagham_new : DbMigration
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
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.Int(nullable: false),
                        fCompanyId = c.Int(nullable: false),
                        AccountStatus = c.Int(nullable: false),
                        EmployeeID = c.String(),
                        RealPass = c.String(),
                        UserId = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        ItemCode = c.String(nullable: false, maxLength: 128),
                        CompanyID = c.Int(nullable: false),
                        ItemName = c.String(),
                        ItemPrice = c.Double(nullable: false),
                        ItemCost = c.Double(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemCode, t.CompanyID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        VisitorCode = c.Int(nullable: false),
                        VisitorName = c.String(),
                        BirthDateInt = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        VistDateInt = c.Int(nullable: false),
                        VistDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone1 = c.String(),
                        Address = c.String(),
                        GenderCode = c.Int(nullable: false),
                        NationalityCode = c.Int(nullable: false),
                        SourceCode = c.Int(nullable: false),
                        JobCode = c.Int(nullable: false),
                        Note = c.String(),
                        Interseted = c.Boolean(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.VisitorCode })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitors", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Trainers", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Subscriptions", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Subscribers", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Sources", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PlaceOfBirths", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Nationalities", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Items", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Groups", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.CustomerCompanies", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Companies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Visitors", new[] { "CompanyID" });
            DropIndex("dbo.Trainers", new[] { "CompanyID" });
            DropIndex("dbo.Subscriptions", new[] { "CompanyID" });
            DropIndex("dbo.Subscribers", new[] { "CompanyID" });
            DropIndex("dbo.Sources", new[] { "CompanyID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PlaceOfBirths", new[] { "CompanyID" });
            DropIndex("dbo.Nationalities", new[] { "CompanyID" });
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropIndex("dbo.Items", new[] { "CompanyID" });
            DropIndex("dbo.Groups", new[] { "CompanyID" });
            DropIndex("dbo.CustomerCompanies", new[] { "CompanyID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Companies", new[] { "UserId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.Trainers");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Sources");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PlaceOfBirths");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Jobs");
            DropTable("dbo.Items");
            DropTable("dbo.Groups");
            DropTable("dbo.CustomerCompanies");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
        }
    }
}
