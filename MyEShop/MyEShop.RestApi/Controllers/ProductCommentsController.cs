using Microsoft.AspNetCore.Mvc;
using MyEShop.Services.ProductComments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi.Controllers
{
    [ApiController,Route("api/product-comments")]
    public class ProductCommentsController : Controller
    {
        private readonly ProductCommentServices _services;

        public ProductCommentsController(ProductCommentServices services)
        {
            _services = services;
        }

        [HttpPost("{productId}")]
        public async Task<int> Add(int productId,AddCommmentDto dto)
        {
            return await _services.Add(productId, dto);
        }

        [HttpPost]
        [Route("commentId")]
        public async Task<int> AddReplyComment([Required]int commentId, AddCommmentDto dto)
        {
            return await _services.AddReplyComment(commentId, dto);
        }
    }
}
