using AutoMapper;
using System;
using VShop.Model;

namespace VShop.Mapping.AutoMapperProfile
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            //Product category
            CreateMap<ProductCategory, ProductCategoryListResponse>()
               // .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreateDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));

            CreateMap<ProductCategory, ProductCategoryDetailResponse>();
               //  .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreateDate, DateTimeKind.Utc)))
                // .ForMember(dest => dest.UpdateDate, opt => opt.ResolveUsing(src => src.UpdateDate.HasValue ? DateTime.SpecifyKind(src.UpdateDate.Value, DateTimeKind.Utc) : src.UpdateDate));
            //CreateMap<ProductCategory, ProductCategoryDropdownListResponse>();

            //Brand
            //CreateMap<Brand, BrandDropdownListResponse>();
            //CreateMap<Brand, BrandListResponse>()
            //    .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));
            CreateMap<Brand, BrandDetailResponse>();

            //Product
            CreateMap<Product, ProductListResponse>()
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<Product, ProductDetailResponse>();
        }
    }
}