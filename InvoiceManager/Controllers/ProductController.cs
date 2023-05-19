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
    public class ProductController : Controller
    {
        private ProductRepository _productRepository = new ProductRepository();

        public ActionResult Products()
        {
            var userId = User.Identity.GetUserId();
            var clients = _productRepository.GetProducts(userId);
            return View(clients);
        }

        public ActionResult Product(int id = 0)
        {
            var userId = User.Identity.GetUserId();

            var product = id == 0 ?
                GetNewProduct(userId) :
                _productRepository.GetProduct(id, userId);

            var vm = PrepareProductVm(product, userId);

            return View(vm);
        }

        private EditProductViewModel PrepareProductVm(Product product, string userId)
        {
            return new EditProductViewModel
            {
                Product = product,
                Heading = product.Id == 0 ? "Dodawanie nowego produktu" : "Produkt"
            };
        }

        private Product GetNewProduct(string userId)
        {
            return new Product
            {
                UserId = userId,
            };
        }

        [HttpPost]
        public ActionResult Product(Product product)
        {
            var userId = User.Identity.GetUserId();
            product.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = PrepareProductVm(product, userId);
                return View("Product", vm);
            }

            if (product.Id == 0)
                _productRepository.Add(product);

            else
                _productRepository.Update(product);

            return RedirectToAction("Products");
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {

            try
            {
                var userId = User.Identity.GetUserId();
                _productRepository.Delete(id, userId);
            }
            catch (Exception e)
            {

                return Json(new { Success = false, Message = e.Message });
            }

            return Json(new { Success = true });
        }
    }
}
