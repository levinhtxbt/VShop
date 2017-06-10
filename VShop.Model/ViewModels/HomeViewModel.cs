using System.Collections.Generic;

namespace VShop.Model
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides;

        public IEnumerable<ProductViewModel> LatestProducts;

        public IEnumerable<ProductViewModel> HotProducts;
    }
}