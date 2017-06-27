using System;
using System.ComponentModel.DataAnnotations;

namespace VShop.Model
{
    public class CreateBrandRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyword { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public string CreateBy { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}