using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public void Delete(Product product)
        {
            _set.Remove(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _set.FindAsync(id);
        }
    }
}
