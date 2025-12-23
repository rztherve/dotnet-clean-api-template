using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    void Add(Product product);
}