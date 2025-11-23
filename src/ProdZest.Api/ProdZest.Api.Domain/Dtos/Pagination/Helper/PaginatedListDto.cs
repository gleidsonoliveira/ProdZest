using Microsoft.EntityFrameworkCore;
namespace ProdZest.Api.Domain.Dtos.Pagination.Helper;
public static class PaginatedListDto
{
    public static async Task<PagedListDto<T>> CreateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize) where T : class
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        return new PagedListDto<T>(items, pageNumber, pageSize, count);
    }
}
