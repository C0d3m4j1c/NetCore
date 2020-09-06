using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class UserForRegistrationUser : Profile
    {
        public UserForRegistrationUser()
        {
            CreateMap<UserForRegistration,User>()
            .ForMember(dest => dest.UserName, opt=>opt.MapFrom(src=>src.UserName));
        }
    }
}