using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.Products
{
    public class UpdateProductDto
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