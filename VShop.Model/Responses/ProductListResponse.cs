namespace VShop.Model
{
    public class ProductListResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string ProductCategoryName { get; set; }

        public string BrandName { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public string Description { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public bool Status { get; set; }

        public int ViewCount { get; set; }

        public string Tags { get; set; }

    }
}