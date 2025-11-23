using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProdZest.Api.Domain.Dtos.Pagination.Header;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Dtos.Product.List;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Service;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;
using static System.Net.Mime.MediaTypeNames;

namespace ProdZest.Api.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(ILogger<ProductController> logger, IProductService productService, IMapper mapper)
    {
        _logger = logger;
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet(Name = "get-all-products")]
    [SwaggerOperation(Summary = "Obtém uma lista de produtos de acordo com a paginação informada", Description = "Retorna uma lista completa de produtos.")]
    [SwaggerResponse(200, "A lista de produtos foi retornada com sucesso.")]
    [SwaggerResponse(404, "Nenhum item encontrado.")]
    [ProducesResponseType(typeof(IEnumerable<ProductResponseListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductResponseListDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllProducts([FromQuery] ProductRequest productRequest)
    {
        var result = await _productService.GetAllProductsAsync(productRequest);

        return Ok(new PagedResultDto<ProductResponseListDto>(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages, result));
    }

    [HttpGet("get-product")]
    [SwaggerOperation(Summary = "Obtém um produto de acordo com o id.")]
    [SwaggerResponse(200, "O produto foi retornado com sucesso.")]
    [SwaggerResponse(404, "Nenhum item encontrado.")]
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProduct(long Id)
    {
        try
        {
            if (Id == 0)
                return BadRequest("Registro não localizado.");

            var product = await _productService.GetByIdAsync(Id);
            var result = _mapper.Map<ProductResponseDto>(product);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Error("Erro: {StackTrace} - {InnerException}", ex.StackTrace, ex.InnerException);
            return BadRequest(new { Errors = ex.Message });
        }
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Cria um produto.")]
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] ProductInsertRequestDto requestDto)
    {
        try
        {
            var product = _mapper.Map<Product>(requestDto);
            await _productService.AddAsync(product);

            return Ok();
        }
        catch (ValidationException e)
        {
            var errors = e.Errors.Select(x => x.ErrorMessage).ToList();
            if (errors is not null && errors.Any())
                return BadRequest(new { Errors = errors });
        }
        catch (Exception ex)
        {
            Log.Error("Erro: {StackTrace} - {InnerException}", ex.StackTrace, ex.InnerException);
            return BadRequest(new { Errors = ex.Message });
        }

        return Ok();
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Atualiza o produto.")]
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromQuery] long Id, [FromBody] ProductUpdateRequestDto requestDto)
    {
        try
        {
            if (Id == 0)
                return BadRequest("Registro não localizado.");

            var product = await _productService.GetByIdAsync(Id);
            if (product == null)
                return NotFound();

            _mapper.Map(requestDto, product);
            await _productService.UpdateAsync(product);

            return Ok(_mapper.Map<ProductResponseDto>(product));
        }
        catch (ValidationException e)
        {
            var errors = e.Errors.Select(x => x.ErrorMessage).ToList();
            if (errors is not null && errors.Any())
                return BadRequest(new { Errors = errors });
        }
        catch (Exception ex)
        {
            Log.Error("Erro: {StackTrace} - {InnerException}", ex.StackTrace, ex.InnerException);
            return BadRequest(new { Errors = ex.Message });
        }

        return Ok();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Desativa um produto de acordo com a situação deleted.")]
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromQuery] long Id)
    {
        try
        {
            if (Id == 0)
                return BadRequest("Registro não localizado.");

            await _productService.DeleteAsync(Id);
        }
        catch (Exception ex)
        {
            Log.Error("Erro: {StackTrace} - {InnerException}", ex.StackTrace, ex.InnerException);
            return BadRequest(new { Errors = ex.Message });
        }
        return Ok();
    }
}
