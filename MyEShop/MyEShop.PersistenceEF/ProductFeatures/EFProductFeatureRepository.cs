using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductFeatures
{
    public class EFProductFeatureRepository : ProductFeatureRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductFeature> _set;

        public EFProductFeatureRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductFeatures;
        }
        public void Add(ProductFeature productFeature)
        {
            _set.Add(productFeature);
        }
    }
}
