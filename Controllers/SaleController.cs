using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Model;
using PruebaTecnica.Service;

namespace PruebaTecnica.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _service;

    public SaleController(ISaleService service) {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetSales() {
      var data = await _service.GetAll();
      return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSale(int id) {
      var data = await _service.Get(id);
      return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale(List<SaleParams> saleParams) {
      var data = await _service.Create(saleParams);
      return Ok(data);
    }
  }
}