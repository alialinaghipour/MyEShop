using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Products
{
    public interface ProductRepository
    {
        void Add(Product product);
        Task<Product> FindById(int id);
        void Delete(Product product);
        Task<IList<GetAllProductDto>> GetAll(string filter,int skip,int take);
        Task<int> CountProductByFilter(string filter);
        Task<IList<GetAllProductDto>> GetAll();
        Task<bool> IsExistsById(int id);
    }
}
