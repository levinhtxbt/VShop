using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Product")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string Alias { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        public string MoreImage { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public int ViewCount { get; set; }

        public string Tags { get; set; }

        [ForeignKey("CategoryID")]
        public ProductCategory ProductCategory { get; set; }

        [ForeignKey("BrandID")]
        public Brand Brand { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}