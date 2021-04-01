using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductComments
{
    public interface ProductCommentServices
    {
        Task<int> Add(int productId,AddCommmentDto dto);
        Task<int> AddReplyComment(int commentId, AddCommmentDto dto);
    }
}
