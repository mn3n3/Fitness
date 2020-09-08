namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nagham080920201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "VistDateInt", c => c.Int(nullable: false));
            AddColumn("dbo.Visitors", "VistDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Visitors", "InsUserID", c => c.String());
            AddColumn("dbo.Visitors", "InsDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitors", "InsDateTime");
            DropColumn("dbo.Visitors", "InsUserID");
            DropColumn("dbo.Visitors", "VistDate");
            DropColumn("dbo.Visitors", "VistDateInt");
        }
    }
}
