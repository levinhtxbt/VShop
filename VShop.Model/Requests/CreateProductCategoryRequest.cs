using System;
using System.ComponentModel.DataAnnotations;

namespace VShop.Model
{
    public class CreateProductCategoryRequest
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool HotFlag { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyword { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}