using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("ProductCategory")]
    public class ProductCategory : Auditable
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

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

        [MaxLength(500)]
        public string Description { get; set; }

        public int? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        public bool HotFlag { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ParentID")]
        public virtual ProductCategory Parent { get; set; }
    }
}