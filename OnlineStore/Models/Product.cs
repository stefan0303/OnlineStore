using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public decimal Price { get; set; }

   
        [Required]
        public  ApplicationUser User { get; set; } //Seller of Product
    }
}