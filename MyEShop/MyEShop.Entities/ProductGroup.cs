using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class ProductGroup
    {

        public ProductGroup()
        {
            ProductGroups = new HashSet<ProductGroup>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }

        public HashSet<ProductGroup> ProductGroups { get; set; }
        public ProductGroup Group { get; set; }
    }
}
