using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.ProductGroups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/product-groups")]
    public class ProductGroupsController : Controller
    {
        private readonly ProductGroupServices _services;

        public ProductGroupsController(ProductGroupServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductGroupDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpPut("{id}")]
        public async Task Update(int id,UpdateProductGroupDto dto)
        {
            await _services.Update(id, dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductGroupDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductGroupDto> GetById(int id)
        {
            return await _services.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.Delete(id);
        }
    }
}
