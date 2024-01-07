using CatelogServices.DBModels;
using CatelogServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatelogServices.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repo;
    public ProductController(IProductRepository repo)
    {
        _repo = repo;
    }
    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        return Ok( _repo.GetProduct());  
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProduct(int Id)
    { 
        return Ok(_repo.GetProductById(Id));
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        return Ok( _repo.AddProduct(product));
    }

    [HttpPost("RemoveProduct")]
    public async Task<IActionResult> RemoveProduct(int Id)
    {
        return Ok(_repo.DeleteProduct(Id));
    }



}
