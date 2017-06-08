using AutoMapper;

namespace VShop.Web.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                //For MVC
                x.AddProfile(new VShop.Mapping.AutoMapperProfile.ModelToViewModelProfile());
                x.AddProfile(new VShop.Mapping.AutoMapperProfile.ViewModelToModelProfile());
                //For API
                x.AddProfile(new VShop.Mapping.AutoMapperProfile.ModelToResponseProfile());
                x.AddProfile(new VShop.Mapping.AutoMapperProfile.RequestToModelProfile());
            });
        }
    }
}