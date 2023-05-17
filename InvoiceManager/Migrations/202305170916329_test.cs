namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InvoicePositions", new[] { "Invoiceid" });
            CreateIndex("dbo.InvoicePositions", "InvoiceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InvoicePositions", new[] { "InvoiceId" });
            CreateIndex("dbo.InvoicePositions", "Invoiceid");
        }
    }
}
