using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductTags;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductTags
{
    public class EFProductTagRepository : ProductTagRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductTag> _set;

        public EFProductTagRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductTags;
        }

        public void Delete(ProductTag productTag)
        {
            _set.Remove(productTag);
        }
    }
}
