using System.Collections.Generic;

namespace VShop.Model
{
    public class ProductDetailResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public int ViewCount { get; set; }

        public string Tags { get; set; }
        public ProductCategoryDetailResponse ProductCategory { get; set; }

        public BrandDetailResponse Brand { get; set; }
    }
}