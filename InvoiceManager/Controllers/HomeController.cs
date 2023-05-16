using InvoiceManager.Models.Domains;
using InvoiceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Invoice(int id = 0)
        {
            var vm = new EditInvoiceViewModel
            {
                Clients = new List<Client> { new Client { Id = 1, Name = "Klient 1" } },
                MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment
                {Id = 1, Name = "Przelew"}},
                Heading = "Edycja faktury",
                Invoice = new Invoice()
            };

            return View(vm);
        }
    }
}