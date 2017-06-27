using System;
using System.ComponentModel.DataAnnotations;

namespace VShop.Model
{
    public class UpdateBrandRequest
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyword { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}