using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGroups.Contracts
{
    public interface ProductGroupServices
    {
        Task<int> Add(AddProductGroupDto dto);
        Task Update(int id,UpdateProductGroupDto dto);
        Task<IList<GetAllProductGroupDto>> GetAll();
        Task<GetByIdProductGroupDto> GetById(int id);
        Task Delete(int id);
    }
}
