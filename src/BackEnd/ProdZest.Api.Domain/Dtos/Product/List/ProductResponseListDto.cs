namespace ProdZest.Api.Domain.Dtos.Product.List;
public class ProductResponseListDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal GrossPrice { get; set; }
    public int StockQuantity { get; set; }
}
