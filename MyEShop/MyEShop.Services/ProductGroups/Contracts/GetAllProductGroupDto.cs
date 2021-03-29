using System.Collections.Generic;

namespace MyEShop.Services.ProductGroups.Contracts
{
    public class GetAllProductGroupDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountSubGroups { get; set; }
    }
}