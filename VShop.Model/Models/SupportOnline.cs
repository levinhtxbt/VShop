using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("SupportOnline")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Department { get; set; }

        [MaxLength(250)]
        public string Skype { get; set; }

        [MaxLength(250)]
        public string Mobile { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        public bool Status { get; set; }
    }
}