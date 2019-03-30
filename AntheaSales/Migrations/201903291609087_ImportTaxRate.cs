namespace AntheaSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportTaxRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImportTaxRate", c => c.Double());
            DropColumn("dbo.Products", "Imported");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Imported", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "ImportTaxRate");
        }
    }
}
