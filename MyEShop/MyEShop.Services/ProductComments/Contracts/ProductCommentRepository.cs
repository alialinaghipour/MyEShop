using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductComments
{
    public interface ProductCommentRepository
    {
        Task<ProductComment> FindById(int id);
    }
}
