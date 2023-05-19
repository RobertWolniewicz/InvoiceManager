using InvoiceManager.Models.Domains;
using InvoiceManager.Models.Repositorys;
using InvoiceManager.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private ClientRepository _clientRepository = new ClientRepository();

        public ActionResult Clients()
        {
            var userId = User.Identity.GetUserId();
            var clients = _clientRepository.GetClients(userId);
            return View(clients);
        }

        public ActionResult Client(int id = 0)
        {
            var userId = User.Identity.GetUserId();

            var client = id == 0 ?
                GetNewClient(userId) :
                _clientRepository.GetClient(id, userId);

            var vm = PrepareClientVm(client, userId);

            return View(vm);
        }

        private EditClientViewModel PrepareClientVm(Client client, string userId)
        {
            return new EditClientViewModel
            {
                Client = client,
                Heading = client.Id == 0 ? "Dodawanie nowego klienta" : "Klient"
            };
        }

        private Client GetNewClient(string userId)
        {
            return new Client
            {
                UserId = userId,
            };
        }

        [HttpPost]
        public ActionResult Client(Client client)
        {
            var userId = User.Identity.GetUserId();
            client.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = PrepareClientVm(client, userId);
                return View("Client", vm);
            }

            if (client.Id == 0)
                _clientRepository.Add(client);

            else
                _clientRepository.Update(client);

            return RedirectToAction("Clients");
        }

        [HttpPost]
        public ActionResult DeleteClient(int id)
        {

            try
            {
                var userId = User.Identity.GetUserId();
                _clientRepository.Delete(id, userId);
            }
            catch (Exception e)
            {

                return Json(new { Success = false, Message = e.Message });
            }

            return Json(new { Success = true });
        }
    }
}