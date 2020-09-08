namespace Fitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nagham080920202 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Visitors", "UnInterseted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visitors", "UnInterseted", c => c.Boolean(nullable: false));
        }
    }
}
