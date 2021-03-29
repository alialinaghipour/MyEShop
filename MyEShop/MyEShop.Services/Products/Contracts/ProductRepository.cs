using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Services.Products
{
    public interface ProductRepository
    {
        void Add(Product product);
    }
}
