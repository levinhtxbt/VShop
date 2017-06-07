using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Brand")]
    public class Brand : Auditable
    {
        public Brand()
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
        public string Logo { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}