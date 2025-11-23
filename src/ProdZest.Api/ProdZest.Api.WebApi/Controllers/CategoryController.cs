using Microsoft.AspNetCore.Mvc;
using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Category.List;
using ProdZest.Api.Domain.Dtos.Pagination.Header;
using ProdZest.Api.Domain.Interfaces.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace ProdZest.Api.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;
    public CategoryController(ILogger<CategoryController> logger,
        ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet(Name = "get-all-categories")]
    [SwaggerOperation(Summary = "Obtém uma lista de categorias de acordo com a paginação informada", Description = "Retorna uma lista completa de categorias.")]
    [SwaggerResponse(200, "A lista de categorias foi retornada com sucesso.")]
    [SwaggerResponse(404, "Nenhum item encontrado.")]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponseList>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CategoryResponseList), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCategories([FromQuery] CategoryRequest categoryRequest)
    {
        var result = await _categoryService.GetAllCategoriesAsync(categoryRequest);

        return Ok(new PagedResultDto<CategoryResponseList>(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages, result));
    }
}