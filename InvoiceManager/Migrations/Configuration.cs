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
            var paymentByCach = new MethodOfPayment { Name = "Gotówka" };
            var paymentByTransfer = new MethodOfPayment { Name = "Przelew" };

                context.MethodOfPayments.AddOrUpdate(paymentByCach, paymentByTransfer);           
          
        }
    }
}
