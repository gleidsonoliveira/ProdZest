using Microsoft.AspNetCore.Mvc;
using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Category.List;
using ProdZest.Api.Domain.Dtos.Paginacao;
using ProdZest.Api.Domain.Dtos.Paginacao.Filter;
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

    [HttpGet(Name = "get-all-category")]
    [SwaggerOperation(Summary = "Obtém a agenda de leilões de acordo com a paginação informada", Description = "Retorna uma lista completa de leilões abertos.")]
    [SwaggerResponse(200, "A lista de leilões foi retornada com sucesso.")]
    [SwaggerResponse(404, "Nenhum item encontrado.")]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponseList>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CategoryResponseList), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<PagedResponse<IEnumerable<CategoryResponseList>>> GetAllAuctionAsync([FromQuery] FiltroPaginacao filtroPaginacao, [FromBody] CategoryRequest request)
    {
        _logger.LogInformation("Iniciando a busca da agenda de leilões rateio cadastrados.");
        var result = await _categoryService.GetAllCategoriesAsync(filtroPaginacao, request);
        return result;
    }

}
