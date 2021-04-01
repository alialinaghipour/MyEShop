using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class Feature
    {
        public Feature()
        {
            ProductFeatures = new HashSet<ProductFeature>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public HashSet<ProductFeature> ProductFeatures { get; set; }
    }
}
