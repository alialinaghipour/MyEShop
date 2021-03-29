using System;

namespace MyEShop.Services.Products
{
    public class GetAllProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public DateTime CreateData { get; set; }
    }
}