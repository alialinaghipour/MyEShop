using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<Product> _set;
        public EFProductRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.Products;
        }

        public void Add(Product product)
        {
            _set.Add(product);
        }
    }
}
