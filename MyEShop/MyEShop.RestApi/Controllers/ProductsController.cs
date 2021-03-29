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
    }
}