using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(Guid id)
        => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
        => _products.Add(product);
}
