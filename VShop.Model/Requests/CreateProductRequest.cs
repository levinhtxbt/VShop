using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VShop.Model
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public int? BrandID { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public string Tags { get; set; }

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
