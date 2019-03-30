namespace AntheaSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "tags", c => c.String());
        }
    }
}
