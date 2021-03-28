using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.ProductGroups.Contracts
{
    public class AddProductGroupDto
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public int ParentId { get; set; }
    }
}