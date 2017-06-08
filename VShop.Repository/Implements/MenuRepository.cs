using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class MenuRepository : BaseRepository<MenuGroup>, IMenuGroupRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}