using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.Model;
using VShop.Repository;

namespace VShop.Service
{
    public class CommonService : ICommonService
    {

        #region Property / Contructor
        private readonly ISlideRepository _slideRepository;

        public CommonService(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }
        #endregion

        public IEnumerable<Slide> GetSlide()
        {
            var slide = _slideRepository.GetMulti(x => x.Status).OrderBy(s => s.DisplayOrder);
            return slide;
        }
    }
}
