using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Models;
using OnlineStore.ViewModels;

namespace OnlineStore.Services
{
    public class ProductsService : Service
    {
        public IEnumerable<AllProductsVm> GetAllProducts()
        {
            IEnumerable<Product> products = this.Context.Products;
            IEnumerable<AllProductsVm> viewModels = Mapper.Instance.Map<IEnumerable<Product>, IEnumerable<AllProductsVm>>(products);
            return viewModels;
        }
    }
}
