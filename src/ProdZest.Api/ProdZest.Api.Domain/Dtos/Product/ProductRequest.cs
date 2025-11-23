
using ProdZest.Api.Domain.Dtos.Base;
using ProdZest.Api.Domain.Enum;

namespace ProdZest.Api.Domain.Dtos.Product;
public class ProductRequest : BaseRequestDto
{
    public string Description { get; set; }
    public Situation Situation { get; set; }
}
