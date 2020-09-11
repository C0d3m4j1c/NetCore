using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductTypeForUpdateProductType : Profile
    {
        public ProductTypeForUpdateProductType()
        {
            CreateMap<ProductTypeForUpdate,ProductType>()
            .ForMember(dest => dest.Id, opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest => dest.ProductTypeName, opt=>opt.MapFrom(src=>src.ProductTypeName))
            .ForMember(dest => dest.Comments, opt =>opt.MapFrom(src=>src.Comments))
            ;
        }
    }
}