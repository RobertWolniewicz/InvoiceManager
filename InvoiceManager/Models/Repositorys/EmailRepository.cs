using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositorys
{
    public class EmailRepository
    {
        public EmailConfig GetEmailConfig()
        {
            using (var context = new ApplicationDbContext())
            {
               return  context.EmailConfigs.FirstOrDefault();
            }
        }
    }
}