using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Domains
{
    public class InvoicePosition
    {
        public int Id { get; set; }
        public int Lp { get; set; }
        public int Invoiceid { get; set; }
        public decimal Value { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}