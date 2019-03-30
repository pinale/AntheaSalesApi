namespace AntheaSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "tags");
        }
    }
}
