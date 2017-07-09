using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VShop.Model
{
    public class MenuProductCategoryViewModel
    {
        public int ID { get; set; }

        public string Alias { get; set; }

        public int? DisplayOrder { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public List<MenuProductCategoryViewModel> Children { get; set; }
    }
}
