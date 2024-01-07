using CatelogServices.DBModels;
using CatelogServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatelogServices.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogRepository catalog;
    public CatalogController(ICatalogRepository _catalog)
    {
        catalog = _catalog;
    }

    [HttpGet]
    public async Task<IActionResult> GetCatagories()
    {
        return Ok(catalog.GetCategories());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetCatagoryById(int Id)
    {
        return Ok(catalog.GetCategoryById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> AddCatagory(Category category)
    {
        return Ok(catalog.AddCategory(category));
    }

    [HttpDelete("RemoveProduct")]
    public async Task<IActionResult> RemoveCatagoryById(int Id)
    {
        return Ok(catalog.DeleteCategory(Id));
    }

}
