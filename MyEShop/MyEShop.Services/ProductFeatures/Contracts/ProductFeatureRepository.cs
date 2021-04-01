using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductFeatures
{
    public interface ProductFeatureRepository
    {
        void Add(ProductFeature productFeature);
        Task<IList<GetByProductIdProductFeatureDto>> GetByProductId(int productId);
    }
}
