using MyApp.Domain.Entities;
using MyApp.Application.DTOs;

namespace MyApp.Application.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDto> GetAll();
    ProductDto? GetById(Guid id);
    ProductDto Create(CreateProductDto dto);
}