namespace ProdZest.Api.Domain.Dtos.Product;
public record class ProductResponseDto(
    string Description,
    decimal UnitPrice,
    decimal GrossPrice,
    int StockQuantity,
    long CategoryId
);