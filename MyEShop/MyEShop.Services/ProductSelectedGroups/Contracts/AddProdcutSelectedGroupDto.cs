using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.ProductSelectedGroups
{
    public class AddProdcutSelectedGroupDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ProductGroupId { get; set; }
    }
}