using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.ViewModels
{
    public class EmailContactViewModel
    {
        [Required(ErrorMessage = "Pole Email jest wymagane.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
        [Display(Name = "Tytuł")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Pole Wiadomość jest wymagane.")]
        [Display(Name = "Wiadomość")]
        public string Message { get; set; }
    }
}