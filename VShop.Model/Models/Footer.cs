using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        [MaxLength(250)]
        public string ID { get; set; }

        [Required]
        public string Content { get; set; }

        public bool Status { get; set; }
    }
}