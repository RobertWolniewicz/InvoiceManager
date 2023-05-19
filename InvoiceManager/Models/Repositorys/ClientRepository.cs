using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace InvoiceManager.Models.Repositorys
{
    public class ClientRepository
    {
        public List<Client> GetClients(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients.Where(c => c.UserId == userId).ToList();
            }
        }

        public Client GetClient(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients.Include(c => c.Address).Single(c => c.Id == id && c.UserId == userId);
            }
        }

        public void Add(Client client)
        {
            using (var context = new ApplicationDbContext())
            { 
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public void Update(Client client)
        {
            using (var context = new ApplicationDbContext())
            {
                var clientToUpdate = context.Clients
                    .Single(c => c.Id == client.Id && c.UserId == client.UserId);

                clientToUpdate.Name = client.Name;
                clientToUpdate.Email = client.Email;
                clientToUpdate.Address = client.Address;

                context.SaveChanges();
            }
        }

        internal void Delete(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var clientToDelete = context.Clients
                    .Single(c => c.Id == id && c.UserId == userId);
                context.Clients.Remove(clientToDelete);
                context.SaveChanges();
            }
        }
    }
}