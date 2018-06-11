using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineStore.Models;
using OnlineStore.ViewModels;

namespace OnlineStore.Services
{
    public class ProductsService : Service
    {
        public IEnumerable<AllProductsVm> GetAllProducts()
        {
            IEnumerable<Product> products = this.Context.Products.ToList();
            IEnumerable<AllProductsVm> viewModels = Mapper.Instance.Map<IEnumerable<Product>, IEnumerable<AllProductsVm>>(products);
            return viewModels;
        }
    }
}