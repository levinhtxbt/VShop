using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        public int GroupID { get; set; }

        [MaxLength(10)]
        public string Target { get; set; }

        public bool Status { get; set; }

        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; }
    }
}