using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Products
{
    public interface ProductServices
    {
        Task<int> Add(AddProductDto dto);
        Task Update(int id, UpdateProductDto dto);
        Task Delete(int id);
    }
}
