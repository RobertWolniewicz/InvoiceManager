namespace InvoiceManager.Migrations
{
    using InvoiceManager.Models.Domains;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InvoiceManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InvoiceManager.Models.ApplicationDbContext context)
        {
            var paymentByCach = new MethodOfPayment { Id = 1, Name = "Gotówka" };
            var paymentByTransfer = new MethodOfPayment { Id = 2, Name = "Przelew" };
            var emailConfig = new EmailConfig 
            { 
                Id = 1, 
                HostSmtp = "smtp.gmail.com", 
                Port = 587, EnableSsl = true, 
                SenderEmail = "reportservicessender@gmail.com", 
                SenderEmailPassword = "tajnehasło",
                ContactEmail = "robert_wol@wp.pl"
            };

                context.MethodOfPayments.AddOrUpdate(paymentByCach, paymentByTransfer);
            context.EmailConfigs.AddOrUpdate(emailConfig);
          
        }
    }
}
