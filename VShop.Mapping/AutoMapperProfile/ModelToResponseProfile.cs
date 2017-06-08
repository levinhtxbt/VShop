using AutoMapper;
using VShop.Model;

namespace VShop.Mapping.AutoMapperProfile
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            //Product category
            //CreateMap<ProductCategory, ProductCategoryListResponse>()
            //    .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count))
            //    .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent == null ? string.Empty : src.Parent.Name));
            //CreateMap<ProductCategory, ProductCategoryDetailResponse>();
            //CreateMap<ProductCategory, ProductCategoryDropdownListResponse>();

            ////Brand
            //CreateMap<Brand, BrandDropdownListResponse>();
            //CreateMap<Brand, BrandListResponse>()
            //    .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));
            //CreateMap<Brand, BrandDetailResponse>();

            ////Product
            //CreateMap<Product, ProductListResponse>()
            //    .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name))
            //    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));

            //CreateMap<Product, ProductDetailResponse>();
        }
    }
}