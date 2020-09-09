namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permission090920NS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ShowCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowUser", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddUser", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateUser", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteUser", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintUser", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowSource", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddSource", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateSource", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteSource", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintSource", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowCustomerCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddCustomerCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateCustomerCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteCustomerCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintCustomerCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowNationality", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddNationality", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateNationality", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeleteNationality", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintNationality", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShowPlaceOfBirth", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddPlaceOfBirth", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdatePlaceOfBirth", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeletePlaceOfBirth", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrintPlaceOfBirth", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PrintPlaceOfBirth");
            DropColumn("dbo.AspNetUsers", "DeletePlaceOfBirth");
            DropColumn("dbo.AspNetUsers", "UpdatePlaceOfBirth");
            DropColumn("dbo.AspNetUsers", "AddPlaceOfBirth");
            DropColumn("dbo.AspNetUsers", "ShowPlaceOfBirth");
            DropColumn("dbo.AspNetUsers", "PrintNationality");
            DropColumn("dbo.AspNetUsers", "DeleteNationality");
            DropColumn("dbo.AspNetUsers", "UpdateNationality");
            DropColumn("dbo.AspNetUsers", "AddNationality");
            DropColumn("dbo.AspNetUsers", "ShowNationality");
            DropColumn("dbo.AspNetUsers", "PrintJob");
            DropColumn("dbo.AspNetUsers", "DeleteJob");
            DropColumn("dbo.AspNetUsers", "UpdateJob");
            DropColumn("dbo.AspNetUsers", "AddJob");
            DropColumn("dbo.AspNetUsers", "ShowJob");
            DropColumn("dbo.AspNetUsers", "PrintCustomerCompany");
            DropColumn("dbo.AspNetUsers", "DeleteCustomerCompany");
            DropColumn("dbo.AspNetUsers", "UpdateCustomerCompany");
            DropColumn("dbo.AspNetUsers", "AddCustomerCompany");
            DropColumn("dbo.AspNetUsers", "ShowCustomerCompany");
            DropColumn("dbo.AspNetUsers", "PrintItem");
            DropColumn("dbo.AspNetUsers", "DeleteItem");
            DropColumn("dbo.AspNetUsers", "UpdateItem");
            DropColumn("dbo.AspNetUsers", "AddItem");
            DropColumn("dbo.AspNetUsers", "ShowItem");
            DropColumn("dbo.AspNetUsers", "PrintTrainer");
            DropColumn("dbo.AspNetUsers", "DeleteTrainer");
            DropColumn("dbo.AspNetUsers", "UpdateTrainer");
            DropColumn("dbo.AspNetUsers", "AddTrainer");
            DropColumn("dbo.AspNetUsers", "ShowTrainer");
            DropColumn("dbo.AspNetUsers", "PrintSource");
            DropColumn("dbo.AspNetUsers", "DeleteSource");
            DropColumn("dbo.AspNetUsers", "UpdateSource");
            DropColumn("dbo.AspNetUsers", "AddSource");
            DropColumn("dbo.AspNetUsers", "ShowSource");
            DropColumn("dbo.AspNetUsers", "PrintGroup");
            DropColumn("dbo.AspNetUsers", "DeleteGroup");
            DropColumn("dbo.AspNetUsers", "UpdateGroup");
            DropColumn("dbo.AspNetUsers", "AddGroup");
            DropColumn("dbo.AspNetUsers", "ShowGroup");
            DropColumn("dbo.AspNetUsers", "PrintUser");
            DropColumn("dbo.AspNetUsers", "DeleteUser");
            DropColumn("dbo.AspNetUsers", "UpdateUser");
            DropColumn("dbo.AspNetUsers", "AddUser");
            DropColumn("dbo.AspNetUsers", "ShowUser");
            DropColumn("dbo.AspNetUsers", "UpdateCompany");
            DropColumn("dbo.AspNetUsers", "ShowCompany");
        }
    }
}
