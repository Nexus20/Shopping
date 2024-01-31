using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private ILogger<ProductController> _logger;
    private readonly ProductContext _productContext;

    public ProductController(ILogger<ProductController> logger, ProductContext productContext)
    {
        _logger = logger;
        _productContext = productContext;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _productContext.GetAllProductsAsync();
        return Ok(products);
    }
}