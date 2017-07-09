using AutoMapper;
using VShop.Model;

namespace VShop.Mapping.AutoMapperProfile
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<OrderDetail, OrderDetailViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<PostTag, PostTagViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();

            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, SimpleProductViewModel>()
                .ForMember(des => des.ProductCategoryName, x => x.MapFrom(src => src.ProductCategory.Name));

            CreateMap<Tag, TagViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<Brand, BrandViewModel>();
            CreateMap<Product, ProductAutoCompleteViewModel>();
        }
    }
}