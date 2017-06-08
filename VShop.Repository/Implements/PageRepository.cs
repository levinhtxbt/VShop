using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}