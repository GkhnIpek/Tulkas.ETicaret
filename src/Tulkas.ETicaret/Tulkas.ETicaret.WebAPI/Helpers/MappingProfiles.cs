using AutoMapper;
using Tulkas.ETicaret.Core.DbModels;
using Tulkas.ETicaret.WebAPI.Dtos;

namespace Tulkas.ETicaret.WebAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
