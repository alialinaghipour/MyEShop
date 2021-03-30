namespace MyEShop.Services.ProductSelectedGroups
{
    public class GetAllProductSelectedGroupDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductGroupId { get; set; }
        public string GroupTitle { get; set; }
    }
}