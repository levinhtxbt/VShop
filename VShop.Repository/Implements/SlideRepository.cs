using VShop.Data;
using VShop.Model;

namespace VShop.Repository
{
    public class SlideRepository : BaseRepository<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}