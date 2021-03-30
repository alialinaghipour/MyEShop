using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGalleries
{
    public interface ProductGalleryRepository
    {
        void Add(ProductGallery productGallery);
        void Delete(ProductGallery productGallery);
        Task<ProductGallery> FindById(int id);
    }
}
