using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Model;
using PruebaTecnica.Service;

namespace PruebaTecnica.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

    public ProductController(IProductService service) {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts() {
      var data = await _service.GetAll();
      return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id) {
      var data = await _service.Get(id);
      return data != null ? Ok(data) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product) {
      var data = await _service.Create(product);
      return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Product product, int id) {
      var data = await _service.Update(product, id);
      return Ok(data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> UpdateProduct(int id) {
      var data = await _service.Delete(id);
      return Ok(data);
    }
  }
}