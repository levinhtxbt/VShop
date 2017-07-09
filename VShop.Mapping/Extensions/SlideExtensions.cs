using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.Model;

namespace VShop.Mapping.Extensions
{
    public static class SlideExtensions
    {
        public static SlideViewModel ToSlideViewModel(this Slide model)
        {
            var slideViewModel = new SlideViewModel();
            slideViewModel.ID = model.ID;
            slideViewModel.Name = model.Name;
            slideViewModel.URL = model.URL;
            slideViewModel.Image = model.Image;
            slideViewModel.Description = model.Description;
            slideViewModel.DisplayOrder = model.DisplayOrder;
            return slideViewModel;
        }
    }
}
