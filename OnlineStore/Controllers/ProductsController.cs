using Microsoft.AspNet.Identity;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Services;
using OnlineStore.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

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
        public ActionResult EditProduct(Product product)
        {


            return this.View(product);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProductDetail(Product product)
        {
            if (ModelState.IsValid)//Check the model is valid
            {
                string userid = HttpContext.User.Identity.GetUserId();

                using (this.context =  new OnlineStoreContext())
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
        [HttpGet]
        [Route("Products/NewProducts")]
        public ActionResult NewProduct()
        {

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            string userid = HttpContext.User.Identity.GetUserId();
            using (context = new OnlineStoreContext())
            {
               var user = context.Users.FirstOrDefault(u => u.Id == userid);
               product.User = user;
             
                if (ModelState.IsValid)
                {

                    context.Products.Add(product);
                    context.SaveChanges();

                }
                else
                {
                    return View("NewProduct");
                }
            }
            return RedirectToAction("MyProducts");
        }
        

        // Delete Product From List
        [Authorize(Roles = "Admin,User")]
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

        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "User")]
        public ActionResult DeleteAdmin(int? id)
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
            return RedirectToAction("AllProducts");
            //return  MyProducts();           
        }
        //[OutputCache(Duration = 10)]
        [Authorize]
        public  ActionResult AllProducts()
        {
            
            List<AllProductsVm> allUsersAndProducts = new List<AllProductsVm>();
            IEnumerable<ApplicationUser> users;
            using (context = new OnlineStoreContext())
            {
                users = context.Users.ToList();
            }
            foreach (var user in users)
            {
                AllProductsVm allProducts = new AllProductsVm();
                using (context = new OnlineStoreContext())
                {
                    var products = context.Products.Where(p => p.User.Id == user.Id).ToList();
                    allProducts.User = user;
                    allProducts.Products = products;

                    allUsersAndProducts.Add(allProducts);
                }

            }       
            return View("AllProducts", allUsersAndProducts);
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