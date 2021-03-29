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
        Task<GetByIdProductDto> GetById(int id);
        Task<IList<GetAllProductDto>> GetAll(string filter,int pageId, int take);
        Task<IList<GetAllProductDto>> GetAll();
    }
}
