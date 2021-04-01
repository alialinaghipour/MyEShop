using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.Products
{
    public class ProductSelectedGroupDto
    {
        [Required]
        public int GroupId { get; set; }
    }
}