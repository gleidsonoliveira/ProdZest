namespace ProdZest.Api.Domain.Dtos.Product;
public record class ProductRequestDto
{
    public string Description { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal GrossPrice { get; init; }
    public int StockQuantity { get; init; }
    //Reference
    public int CategoryId { get; set; }
}
