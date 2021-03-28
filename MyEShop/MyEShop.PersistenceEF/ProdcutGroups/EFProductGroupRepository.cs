using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductGroups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.PersistenceEF.ProdcutGroups
{
    public class EFProductGroupRepository : ProductGroupRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductGroup> _set;

        public EFProductGroupRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductGroups;
        }

        public void Add(ProductGroup productGroup)
        {
            _set.Add(productGroup);
        }

        public async Task<ProductGroup> FindById(int id)
        {
            return await _set.FindAsync(id);
        }
    }
}
