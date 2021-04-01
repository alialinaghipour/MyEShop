using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Delete(ProductFeature productFeature)
        {
            _set.Remove(productFeature);
        }

        public async Task<ProductFeature> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetByProductIdProductFeatureDto>> GetByProductId(int productId)
        {
            return await _set
                .Where(_ => _.ProductId == productId)
                .Include(_ => _.Product)
                .Include(_ => _.Feature)
                .Select(_ => new GetByProductIdProductFeatureDto
                {
                    Id = _.Id,
                    FeatureId = _.FeatureId,
                    FeatureTitle = _.Feature.Title,
                    Value = _.Value,
                    ProductTitle = _.Product.Title
                })
                .ToListAsync();
        }
    }
}
