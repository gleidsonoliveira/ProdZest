using Microsoft.AspNetCore.Mvc;
using ProdZest.Api.Domain.Interfaces.Service;

namespace ProdZest.Api.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }







}
