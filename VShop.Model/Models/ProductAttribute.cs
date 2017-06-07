using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("ProductAttribute")]
    public class ProductAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}