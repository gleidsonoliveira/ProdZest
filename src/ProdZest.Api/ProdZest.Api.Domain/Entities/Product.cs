using ProdZest.Api.Domain.Entities.Base;

namespace ProdZest.Api.Domain.Entities;
public class Product : EntityBase
{
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal GrossPrice { get; set; }
    public int StockQuantity { get; set; }

    //Reference
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
