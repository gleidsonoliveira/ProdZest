using AutoMapper;
using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.CrossCutting.DependencyInjection.AutoMapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductRequestDto>().ReverseMap();
        CreateMap<Category, CategoryRequest>().ReverseMap();
    }
}
