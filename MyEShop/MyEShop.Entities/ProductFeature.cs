using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
