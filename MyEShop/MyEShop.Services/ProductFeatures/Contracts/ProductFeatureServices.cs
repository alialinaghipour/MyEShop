using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductFeatures
{
    public interface ProductFeatureServices
    {
        Task<int> Add(int productId, AddProductFeatureDto dto);
    }
}
