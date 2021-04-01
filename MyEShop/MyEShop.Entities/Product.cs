using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class Product
    {

        public Product()
        {
            ProductSelectedGroups = new HashSet<ProductSelectedGroup>();
            ProductGalleries = new HashSet<ProductGallery>();
            ProductTags = new HashSet<ProductTag>();
            ProductFeatures = new HashSet<ProductFeature>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public DateTime CreateData { get; set; }

        public HashSet<ProductSelectedGroup> ProductSelectedGroups { get; set; }
        public HashSet<ProductGallery> ProductGalleries { get; set; }
        public HashSet<ProductTag> ProductTags { get; set; }
        public HashSet<ProductFeature> ProductFeatures { get; set; }
    }
}
