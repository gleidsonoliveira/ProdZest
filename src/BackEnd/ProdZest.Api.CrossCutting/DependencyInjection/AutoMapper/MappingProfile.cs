using AutoMapper;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Dtos.Product.List;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.CrossCutting.DependencyInjection.AutoMapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductResponseListDto>().ReverseMap();
        CreateMap<Product, ProductInsertRequestDto>().ReverseMap();
        CreateMap<Product, ProductRequest>().ReverseMap();
        CreateMap<Product, ProductRequestDto>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();
        CreateMap<Product, ProductUpdateRequestDto>().ReverseMap();
    }
}