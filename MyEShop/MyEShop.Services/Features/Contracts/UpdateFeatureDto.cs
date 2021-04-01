using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.Features
{
    public class UpdateFeatureDto
    {
        [Required]
        public string Title { get; set; }
    }
}