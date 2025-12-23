using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
        => _context.Products.ToList();

    public Product? GetById(Guid id)
        => _context.Products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
}
