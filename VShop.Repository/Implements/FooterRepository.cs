using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class FooterRepository : BaseRepository<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}