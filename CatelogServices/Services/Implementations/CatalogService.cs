using CatelogServices.DBModels;
using CatelogServices.DBModels.Models;
using CatelogServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatelogServices.Services.Implementations;

public class CatalogService(AppDBContext dBContext) : ICatalogRepository
{
    public bool AddCategory(Category category)
    {
        dBContext.Categories.AddAsync(category);
        dBContext.SaveChangesAsync();
        return true;

    }

    public bool DeleteCategory(int id)
    {
        if (dBContext is null) return false;
        Category data = dBContext.Categories.FirstOrDefault(x => x.CategoryId == id);
        if (data is null) return false;
        dBContext.Categories.Remove(data);
        return dBContext.SaveChangesAsync().IsCompletedSuccessfully;
    }

    public IEnumerable<Category> GetCategories()
    {
        return dBContext.Categories;
    }

    public Category GetCategoryById(int id)
    {
        return dBContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
    }

}
