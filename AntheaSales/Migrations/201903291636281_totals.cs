namespace AntheaSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "TotalSalesTaxAmount", c => c.Double(nullable: false));
            AddColumn("dbo.OrderItems", "TotalImportTaxAmount", c => c.Double(nullable: false));
            DropColumn("dbo.OrderItems", "TotalTax");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "TotalTax", c => c.Double(nullable: false));
            DropColumn("dbo.OrderItems", "TotalImportTaxAmount");
            DropColumn("dbo.OrderItems", "TotalSalesTaxAmount");
        }
    }
}
