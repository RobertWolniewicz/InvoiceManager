namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LanguageCorrection : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InvoicePositions", new[] { "Productid" });
            CreateIndex("dbo.InvoicePositions", "ProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InvoicePositions", new[] { "ProductId" });
            CreateIndex("dbo.InvoicePositions", "Productid");
        }
    }
}
