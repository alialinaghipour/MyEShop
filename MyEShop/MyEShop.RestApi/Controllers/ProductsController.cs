using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ProductServices _services;

        public ProductsController(ProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpPut("{id}")]
        public async Task Update(int id,UpdateProductDto dto)
        {
            await _services.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductDto> GetById(int id)
        {
            return await _services.GetById(id);
        }

        [HttpGet("{filter}/{pageId}/{take}")]
        public async Task<IList<GetAllProductDto>> GetAll(string filter,int pageId = 1, int take=1)
        {
            return await _services.GetAll(filter,pageId,take);
        }

        [HttpGet]
        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _services.GetAll();
        }
    }
}
