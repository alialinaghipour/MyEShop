using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Services.ProductTags
{
    public interface ProductTagRepository
    {
        void Delete(ProductTag productTag);
    }
}
