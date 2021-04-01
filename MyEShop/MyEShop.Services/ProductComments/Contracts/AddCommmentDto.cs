using System;
using System.ComponentModel.DataAnnotations;

namespace MyEShop.Services.ProductComments
{
    public class AddCommmentDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(800)]
        public string Comment { get; set; }
    }
}