using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
  /// <summary>
  /// Servicio para el manejo de ventas.
  /// </summary>
  public class SaleService : ISaleService
  {
    private readonly DataContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">El contexto de Entity Framework</param>
    public SaleService(DataContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Crea una nueva venta.
    /// </summary>
    /// <param name="saleParams">Una lista de parámetros de la venta a crear.</param>
    /// <returns>Una respuesta HTTP con el resultado de la operación.</returns>
    /// <remarks>
    /// Este método crea una nueva venta en la base de datos. Si la operación es exitosa, el método devuelve una respuesta HTTP con el código de estado 200 y la venta creada. Si la operación falla, el método devuelve una respuesta HTTP con el código de estado 400 o 404, según el motivo del error.
    /// </remarks>
    public async Task<APIResponse<Sale>> Create(List<SaleParams> saleParams)
    {
      APIResponse<Sale> response = new APIResponse<Sale>();
      try
      {
        var sale = new Sale();

        foreach (SaleParams saleParam in saleParams) {
          var product = await _context.Products.FindAsync(saleParam.ProductId);
          if (product == null) {
            response.StatusCode = 404;
            response.Message = "Product not exist";
            return response;
          }

          var saleDetail = new SaleDetail
          {
            IdProduct = product.Id,
            Amount = saleParam.Amount,
            SubTotal = product.Price * saleParam.Amount
          };

          sale.SaleDetails.Add(saleDetail);
        }

        // Calculo el total de la venta
        sale.Total = sale.SaleDetails.Sum(detail => detail.SubTotal);

        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
        response.StatusCode = 200;
        response.Result = sale;
      }
      catch (Exception ex)
      {
        response.StatusCode = 400;
        response.Message = ex.Message;
      }

      return response;
    }


    /// <summary>
    /// Obtiene una venta por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la venta a obtener.</param>
    /// <returns>Una respuesta HTTP con el resultado de la operación.</returns>
    /// <remarks>
    /// Este método obtiene una venta existente de la base de datos por su identificador. Si la operación es exitosa, el método devuelve una respuesta HTTP con el código de estado 200 y la venta encontrada. Si la operación falla, el método devuelve una respuesta HTTP con el código de estado 404.
    /// </remarks>
    public async Task<APIResponse<Sale>> Get(int id)
    {
      var sale = await _context.Sales.Include(sale => sale.SaleDetails).FirstOrDefaultAsync(sale => sale.Id == id);

      APIResponse<Sale> response = new APIResponse<Sale>();
      if (sale != null) response.Result = sale;
      else response.StatusCode = 404; response.Message = "Sale not found";

      return response;
    }

    /// <summary>
    /// Obtiene todas las ventas existentes.
    /// </summary>
    /// <returns>Una lista de ventas.</returns>
    /// <remarks>
    /// Este método devuelve una lista de todas las ventas existentes en la base de datos.
    /// </remarks>
    public async Task<List<Sale>> GetAll()
    {
      return await _context.Sales.Include(sale => sale.SaleDetails).ToListAsync();
    }
  }
}