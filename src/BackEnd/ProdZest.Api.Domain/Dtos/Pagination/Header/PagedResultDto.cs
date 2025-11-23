
namespace ProdZest.Api.Domain.Dtos.Pagination.Header;
public class PagedResultDto<T>
{
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IReadOnlyList<T> Items { get; set; }

    public PagedResultDto(int currentPage, int itemsPerPage, int totalItems, int totalPages, IReadOnlyList<T> items)
    {
        CurrentPage = currentPage;
        ItemsPerPage = itemsPerPage;
        TotalItems = totalItems;
        TotalPages = totalPages;
        Items = items;
    }
}
