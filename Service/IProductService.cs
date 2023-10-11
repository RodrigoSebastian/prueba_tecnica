using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
  /// <summary>
  /// Interfaz para el servicio de productos.
  /// </summary>
  public interface IProductService
  {
    /// <summary>
    /// Obtiene todos los productos existentes.
    /// </summary>
    /// <returns>Una lista de productos.</returns>
    /// <remarks>
    /// Este método devuelve una lista de todos los productos existentes en la base de datos.
    /// </remarks>
    Task<List<Product>> GetAll();

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// </summary>
    /// <param name="id">El identificador del producto a obtener.</param>
    /// <returns>El producto especificado.</returns>
    /// <remarks>
    /// Este método devuelve el producto con el identificador especificado.
    /// </remarks>
    Task<APIResponse<Product>> Get(int id);

    /// <summary>
    /// Elimina un producto existente.
    /// </summary>
    /// <param name="id">El identificador del producto a eliminar.</param>
    /// <returns>Código de estado HTTP 204 si el producto se eliminó correctamente.</returns>
    /// <remarks>
    /// Este método elimina el producto con el identificador especificado.
    /// </remarks>
    Task<APIResponse<Product>> Delete(int id);

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    /// <param name="product">El producto a actualizar.</param>
    /// <param name="id">El identificador del producto a actualizar.</param>
    /// <returns>El producto actualizado.</returns>
    /// <remarks>
    /// Este método actualiza el producto con el identificador especificado con los datos proporcionados.
    /// </remarks>
    Task<APIResponse<Product>> Update(Product product, int id);

    /// <summary>
    /// Crea un nuevo producto.
    /// </summary>
    /// <param name="product">El producto a crear.</param>
    /// <returns>El producto creado.</returns>
    /// <remarks>
    /// Este método crea un nuevo producto a partir de los datos proporcionados.
    /// </remarks>
    Task<APIResponse<Product>> Create(Product product);
  }
}