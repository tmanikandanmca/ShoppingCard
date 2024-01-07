using CatelogServices.DBModels;
namespace CatelogServices.Services.Interfaces;

public interface ICatalogRepository
{
    IEnumerable<Category> GetCategories();
    Category GetCategoryById(int id);
    bool AddCategory(Category category);
    bool DeleteCategory(int id);
}
