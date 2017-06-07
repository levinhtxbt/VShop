using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("Product_ProductAttribute_Mapping")]
    public class Product_ProductAttribute_Mapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int ProductAttributeID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [ForeignKey("ProductAttributeID")]
        public ProductAttribute ProductAttribute { get; set; }
    }
}