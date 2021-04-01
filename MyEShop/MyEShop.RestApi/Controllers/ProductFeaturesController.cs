using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.ProductFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/product-features")]
    public class ProductFeaturesController : Controller
    {
        private readonly ProductFeatureServices _services;

        public ProductFeaturesController(ProductFeatureServices services)
        {
            _services = services;
        }

        [HttpPost("{productId}")]
        public async Task<int> Add(int productId,AddProductFeatureDto dto)
        {
            return await _services.Add(productId, dto);
        }

        [HttpGet("{productId}")]
        public async Task<IList<GetByProductIdProductFeatureDto>> GetByProductId(int productId)
        {
            return await _services.GetByProductId(productId);
        }
    }
}
