using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.ProductGalleries
{
    public class AddProductGalleryDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageName { get; set; }

    }
}