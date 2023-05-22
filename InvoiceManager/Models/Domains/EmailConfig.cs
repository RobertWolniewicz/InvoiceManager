using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Domains
{
    public class EmailConfig
	{
		public int Id { get; set; }
		public string HostSmtp { get; set; }
		public int Port { get; set; }
		public bool EnableSsl { get; set; }
		public string SenderEmail { get; set; }
		public string SenderEmailPassword { get; set; }
		public string ContactEmail { get; set; }
    }
}