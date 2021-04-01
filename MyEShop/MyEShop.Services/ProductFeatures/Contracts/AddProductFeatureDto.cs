using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.ProductFeatures
{
    public class AddProductFeatureDto
    {
        [Required]
        public int FeatureId { get; set; }
        [Required]
        public string Value { get; set; }
    }
}