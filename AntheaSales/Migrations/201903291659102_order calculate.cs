namespace AntheaSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordercalculate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SalesTaxes", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "SalesTaxes");
        }
    }
}
