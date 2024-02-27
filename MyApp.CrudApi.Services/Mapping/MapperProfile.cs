using AutoMapper;
using MyApp.CrudApi.Domain.DTOs;
using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Services.DTOs;

namespace MyApp.CrudApi.Services.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MemberModel, MemberDto>().ReverseMap();
            CreateMap<MembershipPlanModel, MembershipPlanDto>().ReverseMap();
            CreateMap<RegisterUserDto, UserModel>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<LoginUserDto, UserModel>().ReverseMap();
        }
    }
}
