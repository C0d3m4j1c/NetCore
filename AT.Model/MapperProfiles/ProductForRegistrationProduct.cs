using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductForRegistrationProduct : Profile
    {
        public ProductForRegistrationProduct()
        {
            CreateMap<ProductForRegistration,Product>()
            .ForMember(dest => dest.ProductName, opt=>opt.MapFrom(src=>src.ProductName))
            .ForMember(dest => dest.ProductTypeId, opt =>opt.MapFrom(src=>src.ProductTypeId))
            ;
        } 
    }
}