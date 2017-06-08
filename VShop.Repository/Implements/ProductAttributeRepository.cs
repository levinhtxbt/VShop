using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class ProductAttributeRepository : BaseRepository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}