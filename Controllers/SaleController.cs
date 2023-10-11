using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Helper;
using PruebaTecnica.Model;
using PruebaTecnica.Service;

namespace PruebaTecnica.Controllers
{
  /// <summary>
  /// Controlador para las peticiones del modelo Sale
  /// </summary>
  [Route("api/sales")]
  [ApiController]
  [Produces("application/json")]
  public class SaleController : ControllerBase
  {
    private readonly ISaleService _service;

    /// <summary>
    /// Constructor
    /// </summary>
    public SaleController(ISaleService service) {
      _service = service;
    }

    /// <summary>
    /// Obtiene todas las ventas existentes.
    /// </summary>
    /// <returns>Una lista de ventas</returns>
    /// <remarks>
    /// Este método devuelve una lista de todas las ventas existentes en la base de datos.
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(typeof(List<Sale>), 200)]
    [ProducesResponseType(typeof(APIResponse<Sale>), 404)]
    public async Task<IActionResult> GetSales() {
      var data = await _service.GetAll();
      return Ok(data);
    }

    /// <summary>
    /// Obtiene una venta por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la venta a obtener</param>
    /// <returns>La venta especificada</returns>
    /// <remarks>
    /// Este método devuelve la venta con el identificador especificado.
    /// </remarks>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(APIResponse<Sale>), 200)]
    [ProducesResponseType(typeof(APIResponse<Sale>), 404)]
    public async Task<IActionResult> GetSale(int id) {
      var data = await _service.Get(id);
      return Ok(data);
    }

    /// <summary>
    /// Crea una nueva venta.
    /// </summary>
    /// <param name="saleParams">Los parámetros de la venta a crear</param>
    /// <returns>La venta creada</returns>
    /// <remarks>
    /// Este método crea una nueva venta a partir de los parámetros proporcionados.
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(APIResponse<Sale>), 201)]
    [ProducesResponseType(typeof(APIResponse<Sale>), 400)]
    public async Task<IActionResult> CreateSale(List<SaleParams> saleParams) {
      var data = await _service.Create(saleParams);
      return Ok(data);
    }
  }
}
