using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Services.ProductGalleries
{
    public interface ProductGalleryRepository
    {
        void Add(ProductGallery productGallery);
    }
}
