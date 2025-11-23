namespace ProdZest.Api.Domain.Dtos.Base;
public class BaseRequestDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
