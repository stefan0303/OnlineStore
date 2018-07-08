using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualBasic.ApplicationServices;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   
    public class ApplicationUser : IdentityUser, IEnumerable
    {

        public ApplicationUser()
        {
           
            this.Products = new List<Product>();
        }

        public List<Product> Products { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //Check this ApplicationUser is Admin
        //public Boolean IsAdminUser(DbContext context)
        //{
          
        //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //    var s = userManager.GetRoles(this.Id);
        //    if (s[0].ToString() == "Admin")
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}