using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class ProductSelectedGroup
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }
        public Product Product { get; set; }
    }
}
