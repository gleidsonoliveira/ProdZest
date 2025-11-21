using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository;
using ProdZest.Api.Domain.Interfaces.Service;

namespace ProdZest.Api.Service.Services;
public class ProductService(IProductRepository CategoryRepository, IMapper mapper, IValidator<Product> validator) : IProductService
{
}
