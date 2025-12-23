using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var product = _service.GetById(id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(CreateProductDto dto)
    {
        var product = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}
