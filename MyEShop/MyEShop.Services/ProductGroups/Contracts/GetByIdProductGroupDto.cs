using System.Collections.Generic;

namespace MyEShop.Services.ProductGroups.Contracts
{
    public class GetByIdProductGroupDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<SubGroupDto> SubGroupsDto { get; set; }
    }
}