using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.Features
{
    public class AddFeatureDto
    {
        [Required]
        public string Title { get; set; }
    }
}