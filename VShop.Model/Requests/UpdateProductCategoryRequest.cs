using System;
using System.ComponentModel.DataAnnotations;

namespace VShop.Model
{
    public class UpdateProductCategoryRequest
    {
        [Required]
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

        [Required]
        public DateTime? UpdateDate { get; set; }

        [Required]
        public string UpdateBy { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}