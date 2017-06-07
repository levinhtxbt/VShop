using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("LogError")]
    public class LogError
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime CreateDate { get; set; }
    }
}