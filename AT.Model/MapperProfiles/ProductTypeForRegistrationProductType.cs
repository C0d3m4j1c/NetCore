using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductTypeForRegistrationProductType : Profile
    {
        public ProductTypeForRegistrationProductType()
        {
            CreateMap<ProductTypeForRegistration,ProductType>()
            .ForMember(dest => dest.ProductTypeName, opt=>opt.MapFrom(src=>src.ProductTypeName))
            .ForMember(dest => dest.Comments, opt =>opt.MapFrom(src=>src.Comments))
            ;
        }
    }
}