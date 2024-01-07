using CatelogServices.DBModels;

namespace CatelogServices.Services.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProduct();
    Product GetProductById(int id);
    bool AddProduct(Product product);
    bool DeleteProduct(int id);
}
