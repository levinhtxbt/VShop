using System;
using System.ComponentModel.DataAnnotations;

namespace VShop.Model
{
    public abstract class Auditable : IAuditable
    {
        [MaxLength(250)]
        public string MetaDescription { get; set; }

        [MaxLength(250)]
        public string MetaKeyword { get; set; }

        public DateTime CreateDate { get; set; }

        [MaxLength(50)]
        [Required]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [MaxLength(50)]
        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}