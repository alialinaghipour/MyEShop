﻿using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.Products;
using System;
using System.Collections.Generic;
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
    }
}
