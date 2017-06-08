using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class VisitorStatisticRepository : BaseRepository<VisitorStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}