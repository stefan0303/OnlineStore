using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using OnlineStore.Models;

namespace OnlineStore.ViewModels
{
    public class AllProductsVm
    {
        public List<Product> Products { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}