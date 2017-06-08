using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class MenuGroupRepository : BaseRepository<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}