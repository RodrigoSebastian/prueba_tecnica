using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
  /// <summary>
  /// Interfaz para el servicio de ventas.
  /// </summary>
  public interface ISaleService
  {
    /// <summary>
    /// Obtiene todas las ventas existentes.
    /// </summary>
    /// <returns>Una lista de ventas.</returns>
    /// <remarks>
    /// Este método devuelve una lista de todas las ventas existentes en la base de datos.
    /// </remarks>
    Task<List<Sale>> GetAll();

    /// <summary>
    /// Obtiene una venta por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la venta a obtener.</param>
    /// <returns>La venta especificada.</returns>
    /// <remarks>
    /// Este método devuelve la venta con el identificador especificado.
    /// </remarks>
    Task<APIResponse<Sale>> Get(int id);

    /// <summary>
    /// Crea una nueva venta.
    /// </summary>
    /// <param name="saleParams">Los parámetros de la venta a crear.</param>
    /// <returns>La venta creada.</returns>
    /// <remarks>
    /// Este método crea una nueva venta a partir de los parámetros proporcionados.
    /// </remarks>
    Task<APIResponse<Sale>> Create(List<SaleParams> saleParams);
  }
}
