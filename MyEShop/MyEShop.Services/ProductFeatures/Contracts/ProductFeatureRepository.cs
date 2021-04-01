using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Services.ProductFeatures
{
    public interface ProductFeatureRepository
    {
        void Add(ProductFeature productFeature);
    }
}
