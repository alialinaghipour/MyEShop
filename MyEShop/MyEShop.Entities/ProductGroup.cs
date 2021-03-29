using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEShop.Entities
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }

        public HashSet<ProductGroup> ProductGroups { get; set; }
        public ProductGroup ProductGroup1 { get; set; }
        public ProductGroup()
        {
            ProductGroups = new HashSet<ProductGroup>();
        }
    }
}
