using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductTypeForDeletionProductType : Profile
    {
        public ProductTypeForDeletionProductType()
        {
            CreateMap<ProductTypeForDeletion,ProductType>()
            .ForMember(dest => dest.Id, opt=>opt.MapFrom(src=>src.Id))
            ;
        }
    }
}