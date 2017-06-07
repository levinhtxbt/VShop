using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [MaxLength(500)]
        public string CustomerMessage { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(250)]
        public string PaymentMethod { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}