using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/features")]
    public class FeaturesController : Controller
    {
        private readonly FeatureServices _services;

        public FeaturesController(FeatureServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddFeatureDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpPut("{id}")]
        public async Task Update(int id,UpdateFeatureDto dto)
        {
            await _services.Update(id, dto);
        }
    }
}
