using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.Model
{
    [Table("ProductAttributeValue")]
    public class ProductAttributeValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ProductAttributeMappingID { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }

        [ForeignKey("ProductAttributeMappingID")]
        public Product_ProductAttribute_Mapping ProductAttributeMapping { get; set; }
    }
}