using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositorys
{
    public class InvoiceRepository
    {
        public List<Invoice> GetInvoices(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Invoices
                    .Include(i => i.Client)
                    .Where(i => i.UserId == userId)
                    .ToList();
            }
        }

        public Invoice GetInvoice(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Invoices
                   .Include(i => i.InvoicePositions)
                   .Include(i => i.InvoicePositions.Select(ip => ip.Product))
                   .Include(i => i.MethodOfPayment)
                   .Include(i => i.User)
                   .Include(i => i.User.Address)
                   .Include(i => i.Client)
                   .Include(i => i.Client.Address)
                   .Single(i => i.Id == id && i.UserId == userId);
            }
        }

        public List<MethodOfPayment> GetMethodsOfPayment()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.MethodOfPayments.ToList();
            }
        }

        public InvoicePosition GetInvoicePosition(int invoicePositionId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.InvoicePositions
                    .Include(ip => ip.Invoice)
                    .Single(ip => ip.Id == invoicePositionId &&
                    ip.Invoice.UserId == userId);
            }
        }

        public void Add(Invoice invoice)
        {
            using (var context = new ApplicationDbContext())
            {
                invoice.CreatedDate = DateTime.Now;

                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
        }

        public void Update(Invoice invoice)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoiceToUpdate = context.Invoices
                    .Single(i => i.Id == invoice.Id && i.UserId == invoice.UserId);

                invoiceToUpdate.ClientId = invoice.ClientId;
                invoiceToUpdate.Comments = invoice.Comments;
                invoiceToUpdate.MethodOfPayment = invoice.MethodOfPayment;
                invoiceToUpdate.PaymentDate = invoice.PaymentDate;
                invoiceToUpdate.Title = invoice.Title;

                context.SaveChanges();
            }
        }

        public void AddPosition(InvoicePosition invoicePosition, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoice = context.Invoices
                    .Single(i => i.Id == invoicePosition.InvoiceId &&
                    i.UserId == userId);

                context.InvoicePositions.Add(invoicePosition);
                context.SaveChanges();
            }
        }

        public void UpdatePosition(InvoicePosition invoicePosition, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var positionToUpdate = context.InvoicePositions
                    .Include(ip => ip.Product)
                    .Include(ip => ip.Invoice)
                    .Single(ip =>
                    ip.Id == invoicePosition.Id &&
                    ip.Invoice.UserId == userId);

                positionToUpdate.Lp = invoicePosition.Lp;
                positionToUpdate.ProductId = invoicePosition.ProductId;
                positionToUpdate.Quantity = invoicePosition.Quantity;
                positionToUpdate.Value = positionToUpdate.Product.Value * positionToUpdate.Quantity;

                context.SaveChanges();
            }
        }

        public decimal UpdateInvoiceValue(int invoiceId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoice = context.Invoices
                    .Include(i => i.InvoicePositions)
                    .Single(i => i.Id == invoiceId && i.UserId == userId);

                invoice.Value = invoice.InvoicePositions.Sum(ip => ip.Value);

                context.SaveChanges();

                return invoice.Value;
            }
        }

        public void Delete(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoicesToDelete = context.Invoices
                    .Single(i => i.Id == id && i.UserId == userId);
                context.Invoices.Remove(invoicesToDelete);
                context.SaveChanges();
            }
        }

        internal void DeletePosition(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoicePositionToDelete = context.InvoicePositions
                    .Include(ip => ip.Invoice)
                    .Single(ip => ip.Id == id && ip.Invoice.UserId == userId);
                context.InvoicePositions.Remove(invoicePositionToDelete);
                context.SaveChanges();
            }
        }
    }
}