namespace ProdZest.Api.Domain.Dtos.Product;
public record ProductInsertRequestDto(
    string Description,
    decimal UnitPrice,
    decimal GrossPrice,
    int StockQuantity,
    long CategoryId
);

