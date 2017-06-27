﻿using AutoMapper;
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
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));

            CreateMap<ProductCategory, ProductCategoryDetailResponse>();
            //CreateMap<ProductCategory, ProductCategoryDropdownListResponse>();

            CreateMap<Brand, BrandDetailResponse>();

            //Product
            CreateMap<Product, ProductListResponse>()
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<Product, ProductDetailResponse>();

            //Brand
            CreateMap<Brand, BrandListResponse>();
            CreateMap<Brand, BrandDetailResponse>();

        }
    }
}