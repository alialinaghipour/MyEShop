using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductSelectedGroups
{
    public interface ProductSelectedGroupServices
    {
        Task<int> Add(AddProdcutSelectedGroupDto dto);
        Task Delete(int id);
    }
}
