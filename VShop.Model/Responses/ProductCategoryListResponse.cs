namespace VShop.Model
{
    public class ProductCategoryListResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool HotFlag { get; set; }

        public int ProductCount { get; set; }
    }
}