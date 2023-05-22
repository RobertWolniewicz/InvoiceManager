using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManager.Models.Domains
{
    public class Address
    {
        public Address()
        {
            Clients = new Collection<Client>();
            Users= new Collection<ApplicationUser>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Ulica jest wymagane.")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole Numer jest wymagane.")]
        [Display(Name = "Numer")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Pole Miejscowośc jest wymagane.")]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole Kod pocztowy jest wymagane.")]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        public ICollection<Client> Clients { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}