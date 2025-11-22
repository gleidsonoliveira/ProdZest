using ProdZest.Api.Data.Context;
using ProdZest.Api.Data.Repository.Base;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository;

namespace ProdZest.Api.Data.Repository;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProdZestContext prodZestContext) : base(prodZestContext)
    {
    }
}
