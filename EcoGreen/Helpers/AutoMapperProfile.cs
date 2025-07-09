using Application.Entities.Base;
using Application.Entities.DTOs.User;
using AutoMapper;

namespace EcoGreen.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Add your mappings here
            // Example: CreateMap<Source, Destination>();
            // CreateMap<User, UserDto>();
            // CreateMap<Product, ProductDto>();
            // CreateMap<Order, OrderDto>();
            // etc.
            CreateMap<UserRegisterDTO, User>()
     .ForMember(user => user.UserName, opt => opt.MapFrom(userRegis => userRegis.name))
     .ForMember(user => user.Email, opt => opt.MapFrom(userRegis => userRegis.Email))
     .ForMember(user => user.ProfilePhotoUrl, opt => opt.Ignore());

        }
    }
}
