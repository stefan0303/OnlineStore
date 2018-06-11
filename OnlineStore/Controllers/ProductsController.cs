using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Services;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers
{

    public class ProductsController : Controller
    {
        private ProductsService service;

        public ProductsController()
        {
            this.service = new ProductsService();
        }
        // GET: Products
        [Authorize]
        public ActionResult AllProducts()
        {
            OnlineStoreContext context = new OnlineStoreContext();
            IEnumerable<AllProductsVm> products = this.service.GetAllProducts();

          
            using (context)
            {
               // products = context.Products.ToList();//All products
            }
            return View(products);
        }


        [Authorize]
        public ActionResult MyProducts()
        {
            //We get the current loged in user Id
             string userid = HttpContext.User.Identity.GetUserId();

            List<Product> products = new List<Product>();
            OnlineStoreContext context = new OnlineStoreContext();
            using (context)
            {             
                //products = context.Products.Where(p => p.User.Id == userid).ToList();                  
            }

            return View(products);
        }
    }
}