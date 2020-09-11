using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductProductForList : Profile
    {
        public ProductProductForList()
        {
            CreateMap<Product, ProductForList>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(src => src.ProductTypeId))
            ;
        }
    }
}