using VShop.Model;

namespace VShop.Mapping.Extensions
{
    public static class ProductExtensions
    {
        public static void UpdateProduct(this Product product, CreateProductRequest requestModel)
        {
            product.Name            = requestModel.Name;
            product.Alias           = requestModel.Alias;
            product.CategoryID      = requestModel.CategoryID;
            product.BrandID         = requestModel.BrandID;
            product.Image           = requestModel.Image;
            product.MoreImage       = requestModel.MoreImage;
            product.Price           = requestModel.Price;
            product.PromotionPrice  = requestModel.PromotionPrice;
            product.Warranty        = requestModel.Warranty;
            product.Description     = requestModel.Description;
            product.Content         = requestModel.Content;
            product.HomeFlag        = requestModel.HomeFlag;
            product.HotFlag         = requestModel.HotFlag;
            product.Tags            = requestModel.Tags;
            product.MetaDescription = requestModel.MetaDescription;
            product.MetaKeyword     = requestModel.MetaKeyword;
            product.CreateDate      = requestModel.CreateDate;
            product.CreateBy        = requestModel.CreateBy;
            product.Status          = requestModel.Status;

        }

        public static void UpdateProduct(this Product product, UpdateProductRequest requestModel)
        {
            product.ID              = requestModel.ID;
            product.Name            = requestModel.Name;
            product.Alias           = requestModel.Alias;
            product.CategoryID      = requestModel.CategoryID;
            product.BrandID         = requestModel.BrandID;
            product.Image           = requestModel.Image;
            product.MoreImage       = requestModel.MoreImage;
            product.Price           = requestModel.Price;
            product.PromotionPrice  = requestModel.PromotionPrice;
            product.Warranty        = requestModel.Warranty;
            product.Description     = requestModel.Description;
            product.Content         = requestModel.Content;
            product.HomeFlag        = requestModel.HomeFlag;
            product.HotFlag         = requestModel.HotFlag;
            product.Tags            = requestModel.Tags;
            product.MetaDescription = requestModel.MetaDescription;
            product.MetaKeyword     = requestModel.MetaKeyword;
            product.UpdateDate      = requestModel.UpdateDate;
            product.UpdateBy        = requestModel.UpdateBy;
            product.Status          = requestModel.Status;

        }
    }
}