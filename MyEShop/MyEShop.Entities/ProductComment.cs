using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class ProductComment
    {

        public ProductComment()
        {
            ProductComments = new HashSet<ProductComment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }

        public Nullable<int> ParentId { get; set; }
        public ProductComment ProductComment1 { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public HashSet<ProductComment> ProductComments { get; set; }
    }
}
