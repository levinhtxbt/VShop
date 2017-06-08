using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class Product_ProductAttribute_MappingRepository : BaseRepository<Product_ProductAttribute_Mapping>, IProduct_ProductAttribute_MappingRepository
    {
        public Product_ProductAttribute_MappingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}