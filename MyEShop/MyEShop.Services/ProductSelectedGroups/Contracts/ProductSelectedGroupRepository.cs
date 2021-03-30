using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductSelectedGroups
{
    public interface ProductSelectedGroupRepository
    {
        void Add(ProductSelectedGroup productSelectedGroup);
        Task<bool> IsExistsByProductIdAndGroupId(int productId, int groupId);
        void Delete(ProductSelectedGroup productSelectedGroup);
        Task<ProductSelectedGroup> FindById(int id);
    }
}
