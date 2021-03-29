using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.Products
{
    public class AddProductDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Price { get; set; }
    }
}