namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n3n3sdlskdlksldk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "fCompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccountStatus", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EmployeeID", c => c.String());
            AddColumn("dbo.AspNetUsers", "RealPass", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserId", c => c.String());
            CreateIndex("dbo.Companies", "UserId");
            AddForeignKey("dbo.Companies", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.AspNetUsers", "RealPass");
            DropColumn("dbo.AspNetUsers", "EmployeeID");
            DropColumn("dbo.AspNetUsers", "AccountStatus");
            DropColumn("dbo.AspNetUsers", "fCompanyId");
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.Companies", "UserId");
        }
    }
}
