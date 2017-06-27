using VShop.Model;

namespace VShop.Mapping.Extensions
{
    public static class BrandExtensions
    {
        public static void UpdateBrand(this Brand model, CreateBrandRequest createModel)
        {
            model.Name            = createModel.Name;
            model.Alias           = createModel.Alias;
            model.Description     = createModel.Description;
            model.Logo            = createModel.Logo;
            model.MetaDescription = createModel.MetaDescription;
            model.MetaKeyword     = createModel.MetaKeyword;
            model.CreateDate      = createModel.CreateDate;
            model.CreateBy        = createModel.CreateBy;
            model.Status          = createModel.Status;
        }

        public static void UpdateBrand(this Brand model, UpdateBrandRequest updateModel)
        {
            model.Name            = updateModel.Name;
            model.Alias           = updateModel.Alias;
            model.Description     = updateModel.Description;
            model.Logo            = updateModel.Logo;
            model.MetaDescription = updateModel.MetaDescription;
            model.MetaKeyword     = updateModel.MetaKeyword;
            model.UpdateDate      = updateModel.UpdateDate;
            model.UpdateBy        = updateModel.UpdateBy;
            model.Status          = updateModel.Status;
        }
    }
}