using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Slide")]
    public class Slide : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(500)]
        public string Image { get; set; }

        [Required]
        [MaxLength(500)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }
    }
}