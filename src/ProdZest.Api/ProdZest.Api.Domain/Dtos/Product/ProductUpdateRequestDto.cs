namespace ProdZest.Api.Domain.Dtos.Product;
public record  ProductUpdateRequestDto(
    string Description,
    decimal UnitPrice,
    decimal GrossPrice,
    int StockQuantity,
    long CategoryId
);

