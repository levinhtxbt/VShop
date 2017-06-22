using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.Model;

namespace VShop.Mapping.Extensions
{
    public static class ProductCategoryExtension
    {
        public static void UpdateProductCategory(this ProductCategory model, CreateProductCategoryRequest request)
        {
            model.ID              = request.ID;
            model.Name            = request.Name;
            model.Alias           = request.Alias;
            model.Description     = request.Description;
            model.DisplayOrder    = request.DisplayOrder;
            model.HotFlag         = request.HotFlag;
            model.Image           = request.Image;
            model.Status          = request.Status;
            model.CreateBy        = request.CreateBy;
            model.CreateDate      = request.CreateDate;
            model.UpdateBy        = request.UpdateBy;
            model.UpdateDate      = request.UpdateDate;
            model.ParentID        = request.ParentID;
            model.MetaDescription = request.MetaDescription;
            model.MetaKeyword     = request.MetaKeyword;
        }
    }
}
