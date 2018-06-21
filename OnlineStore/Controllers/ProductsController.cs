using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        private OnlineStoreContext context;

        public ProductsController()
        {

            this.service = new ProductsService();
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditProductDetail(Product product)
        {
            if (ModelState.IsValid)//Check the model is valid
            {
                string userid = HttpContext.User.Identity.GetUserId();

                using (this.context = new OnlineStoreContext())
                {
                    var productForEdit = context.Products.FirstOrDefault(p => p.Id == product.Id);
                    var user = context.Users.FirstOrDefault(u => u.Id == userid);

                    productForEdit.Brand = product.Brand;
                    productForEdit.Make = product.Make;
                    productForEdit.Price = product.Price;
                    productForEdit.User = user;
                    context.SaveChanges();
                }
                return RedirectToAction("MyProducts", "Products");
            }

            return RedirectToAction("EditProduct", product);


        }
        [Authorize]
        [HttpPost]
    
        public ActionResult NewProduct()
        {
            if (ModelState.IsValid)
            {

            }
            return this.View();
        }

        [Authorize]
        public ActionResult EditProduct(Product product)
        {


            return this.View(product);
        }

        // Delete Product From List
        [Authorize]
        public ActionResult Delete(int? id)
        {

            using (this.context = new OnlineStoreContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }

            }
            return RedirectToAction("MyProducts");
            //return  MyProducts();           
        }
        [Authorize]
        public ActionResult AllProducts()
        {
            //ToDo make it with ViewModel

            IEnumerable<ApplicationUser> users;
            using (context = new OnlineStoreContext())
            {
                users = context.Users.ToList();
            }


            IDictionary<ApplicationUser, List<Product>> userProducts = new Dictionary<ApplicationUser, List<Product>>();
            foreach (var user in users)
            {
                using (context = new OnlineStoreContext())
                {
                    var products = context.Products.Where(p => p.User.Id == user.Id).ToList();
                    userProducts.Add(user, products);
                }

            }

            return View(userProducts);
        }


        [Authorize]
        public ActionResult MyProducts()
        {
            //We get the current loged in user Id
            string userid = HttpContext.User.Identity.GetUserId();

            List<Product> products;
            using (context = new OnlineStoreContext())
            {
                products = context.Products.Where(p => p.User.Id == userid).OrderBy(p => p.Brand).ThenBy(p => p.Make).ToList();
            }

            return this.View(products);
        }
    }
}