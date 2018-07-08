using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.Models;

namespace OnlineStore.Data
{
    public class OnlineStoreContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineStoreContext()
        : base("OnlineStore")
        {

        }

        //public DbSet<User> User { get; set; }

        public DbSet<Product> Products { get; set; }

        public static OnlineStoreContext Create()
       {
            OnlineStoreContext context = new OnlineStoreContext();

            return context;
        }
  
    }
}