using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class LogErrorRepository : BaseRepository<LogError>, ILogErrorRepository
    {
        public LogErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}