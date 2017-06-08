using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class ProductAttributeValueRepository : BaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}