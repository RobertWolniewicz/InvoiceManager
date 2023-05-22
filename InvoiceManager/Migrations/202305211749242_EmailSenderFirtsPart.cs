namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailSenderFirtsPart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HostSmtp = c.String(),
                        Port = c.Int(nullable: false),
                        EnableSsl = c.Boolean(nullable: false),
                        SenderEmail = c.String(),
                        SenderEmailPassword = c.String(),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailConfigs");
        }
    }
}
