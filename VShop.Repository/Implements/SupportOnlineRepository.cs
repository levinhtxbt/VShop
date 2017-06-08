using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class SupportOnlineRepository : BaseRepository<SupportOnline>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}