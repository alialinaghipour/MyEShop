namespace MyEShop.Services.ProductFeatures
{
    public class GetByProductIdProductFeatureDto
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public string FeatureTitle { get; set; }
        public string Value { get; set; }
        public string ProductTitle { get; set; }
        public int ProductId { get; set; }
    }
}