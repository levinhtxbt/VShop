using AutoMapper;
using VShop.Model;

namespace VShop.Mapping.AutoMapperProfile
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<OrderDetailViewModel, OrderDetail>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<PostCategoryViewModel, PostCategory>();
            CreateMap<PostTagViewModel, PostTag>();
            CreateMap<PostViewModel, Post>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductTagViewModel, ProductTag>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<TagViewModel, Tag>();
        }
    }
}