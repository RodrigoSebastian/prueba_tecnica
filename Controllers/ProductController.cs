using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Helper;
using PruebaTecnica.Model;
using PruebaTecnica.Service;

namespace PruebaTecnica.Controllers
{
  /// <summary>
  /// Controlador para las peticiones del modelo Product
  /// </summary>
  [Route("api/products")]
  [ApiController]
  [Produces("application/json")]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _service;

    /// <summary>
    /// Constructor
    /// </summary>
    public ProductController(IProductService service) {
      _service = service;
    }

    /// <summary>
    /// Obtiene todos los productos existentes.
    /// </summary>
    /// <returns>Una lista de productos</returns>
    /// <remarks>
    /// Este método devuelve una lista de todos los productos existentes en la base de datos.
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(typeof(List<Product>), 200)]
    [ProducesResponseType(typeof(APIResponse<Product>), 404)]
    public async Task<IActionResult> GetProducts() {
      var data = await _service.GetAll();
      return Ok(data);
    }

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// </summary>
    /// <param name="id">El identificador del producto a obtener</param>
    /// <returns>El producto especificado</returns>
    /// <remarks>
    /// Este método devuelve el producto con el identificador especificado.
    /// </remarks>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(APIResponse<Product>), 200)]
    [ProducesResponseType(typeof(APIResponse<Product>), 404)]
    public async Task<IActionResult> GetProduct(int id) {
      var data = await _service.Get(id);
      return Ok(data);
    }

    /// <summary>
    /// Crea un nuevo product.
    /// </summary>
    /// <param name="product">El producto a crear</param>
    /// <returns>El producto creado</returns>
    /// <remarks>
    /// Este método crea un nuevo producto a partir de los datos proporcionados.
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(APIResponse<Product>), 201)]
    [ProducesResponseType(typeof(APIResponse<Product>), 400)]
    public async Task<IActionResult> CreateProduct(Product product) {
      var data = await _service.Create(product);
      return Ok(data);
    }

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    /// <param name="product">El producto a actualizar</param>
    /// <param name="id">El identificador del producto a actualizar</param>
    /// <returns>El producto actualizado</returns>
    /// <remarks>
    /// Este método actualiza el producto con el identificador especificado con los datos proporcionados.
    /// </remarks>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(APIResponse<Product>), 200)]
    [ProducesResponseType(typeof(APIResponse<Product>), 400)]
    [ProducesResponseType(typeof(APIResponse<Product>), 404)]
    public async Task<IActionResult> UpdateProduct(Product product, int id) {
      var data = await _service.Update(product, id);
      return Ok(data);
    }

    /// <summary>
    /// Elimina un producto existente.
    /// </summary>
    /// <param name="id">El identificador del producto a eliminar</param>
    /// <returns>Código de estado HTTP 204 si el producto se eliminó correctamente</returns>
    /// <remarks>
    /// Este método elimina el producto con el identificador especificado.
    /// </remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(APIResponse<Product>), 204)]
    [ProducesResponseType(typeof(APIResponse<Product>), 404)]
    public async Task<IActionResult> UpdateProduct(int id) {
      var data = await _service.Delete(id);
      return Ok(data);
    }
  }
}
