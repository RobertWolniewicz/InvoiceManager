using EmailSender;
using InvoiceManager.Models.Repositorys;
using InvoiceManager.Models.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    public class HomeController : Controller
    {
        private EmailRepository _emailRepository = new EmailRepository();
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact(bool isSent = false)
        {
            if(isSent)
                ViewBag.Message = "Wiadomość została wysłana.";

            return View(PrepareEmailContactVm());
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(EmailContactViewModel model, HttpPostedFileBase fileUploader = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var config = _emailRepository.GetEmailConfig();
            var emailParams = new EmailParams
            {
                HostSmtp = config.HostSmtp,
                Port = config.Port,
                EnableSsl = config.EnableSsl,
                SenderEmail = config.SenderEmail,
                SenderEmailPassword = config.SenderEmailPassword,
                SenderName = model.SenderEmail
            };
            var email = new Email(emailParams);

            await email.Send(model.Subject, model.Message, config.ContactEmail, fileUploader);

            var confirmMessage = "To jest potwierdzenie wysłania wiadomosci o treści:" + Environment.NewLine + model.Message;

            await email.Send(model.Subject, confirmMessage, model.SenderEmail, fileUploader);

            ViewBag.Message = "Wiadomość została wysłana.";

            return RedirectToAction("Contact", new {isSent = true});
        }

        private EmailContactViewModel PrepareEmailContactVm()
        {
            return new EmailContactViewModel();

        }
    }
}