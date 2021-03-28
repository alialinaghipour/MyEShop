using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGroups.Contracts
{
    public interface ProductGroupRepository
    {
        void Add(ProductGroup productGroup);
        Task<ProductGroup> FindById(int id);
        Task<IList<GetAllProductGroupDto>> GetAll();
        Task<IList<ProductGroup>> FindAllByParentId(int id);
    }
}
