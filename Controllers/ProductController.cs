using Microsoft.AspNetCore.Mvc;
using RedisExemplo.Models;
using RedisExemplo.Services;

namespace RedisExemplo.Controller;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{

    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var cacheData = _productService.GetAllProducts();
        return new OkObjectResult(cacheData);
    }
}