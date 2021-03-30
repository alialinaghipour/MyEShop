using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.ProductSelectedGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/product-selected-groups")]
    public class ProductSelectedGroupsController : Controller
    {
        private readonly ProductSelectedGroupServices _services;

        public ProductSelectedGroupsController(ProductSelectedGroupServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProdcutSelectedGroupDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
             await _services.Delete(id);
        }

        [HttpGet]
        public async Task<IList<GetAllProductSelectedGroupDto>> GetAll()
        {
            return await _services.GetAll();
        }
    }
}
