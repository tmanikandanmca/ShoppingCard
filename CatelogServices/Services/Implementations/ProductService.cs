using CatelogServices.DBModels;
using CatelogServices.DBModels.Models;
using CatelogServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatelogServices.Services.Implementations;

public class ProductService(AppDBContext dBContext) : IProductRepository
{
    public bool AddProduct(Product category)
    {
        dBContext.Products.Add(category);
        return dBContext.SaveChangesAsync().IsCompletedSuccessfully;
    }

    public bool DeleteProduct(int id)
    {
        var data= dBContext.Products.FirstOrDefault(e=>e.ProductId==id);
        if (data is null) return false;
        dBContext.Remove(data);
        return true;
    }

    public IEnumerable<Product> GetProduct()
    {
        return dBContext.Products;
    }

    public Product GetProductById(int id)
    {
      return dBContext.Products.Where(e=>e.ProductId==id).FirstOrDefault();
    }
}
