using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.ProductGalleries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/product-gallery")]
    public class ProductGalleriesController : Controller
    {
        private readonly ProductGalleryServices _services;

        public ProductGalleriesController(ProductGalleryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductGalleryDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.Delete(id);
        }
    }
}
