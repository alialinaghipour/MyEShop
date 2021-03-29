using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Products
{
    public interface ProductRepository
    {
        void Add(Product product);
        Task<Product> FindById(int id);
    }
}
