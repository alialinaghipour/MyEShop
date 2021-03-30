using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGalleries
{
    public interface ProductGalleryServices
    {
        Task<int> Add(AddProductGalleryDto dto);
        Task Delete(int id);
    }
}
