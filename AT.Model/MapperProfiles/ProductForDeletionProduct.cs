using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductForDeletionProduct : Profile
    {
        public ProductForDeletionProduct()
        {
            CreateMap<ProductForDeletion,Product>()
            .ForMember(dest => dest.Id, opt=>opt.MapFrom(src=>src.Id))
            ;
        } 
    }
}