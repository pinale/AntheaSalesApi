namespace AntheaSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calculate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDescription");
        }
    }
}
