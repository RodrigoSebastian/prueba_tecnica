using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
  /// <summary>
  /// Servicio para el manejo de productos.
  /// </summary>
  public class ProductService : IProductService
  {
    private readonly DataContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">El contexto de Entity Framework</param>
    public ProductService(DataContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Crea un nuevo producto.
    /// </summary>
    /// <param name="product">El producto a crear.</param>
    /// <returns>El producto creado.</returns>
    /// <remarks>
    /// Este método crea un nuevo producto en la base de datos. Si la operación es exitosa, el método devuelve el producto creado. Si la operación falla, el método devuelve un valor null.
    /// </remarks>
    public async Task<APIResponse<Product>> Create(Product product)
    {
      APIResponse<Product> response = new APIResponse<Product>();
      try
      {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        response.StatusCode = 200;
        response.Result = product;
      }
      catch (Exception ex)
      {
        response.StatusCode = 400;
        response.Message = ex.Message;
      }

      return response;
    }

    /// <summary>
    /// Elimina un producto existente.
    /// </summary>
    /// <param name="id">El identificador del producto a eliminar.</param>
    /// <returns>Código de estado HTTP 200 si el producto se eliminó correctamente.</returns>
    /// <remarks>
    /// Este método elimina un producto existente de la base de datos. Si la operación es exitosa, el método devuelve el código de estado HTTP 200. Si la operación falla, el método devuelve un valor null.
    /// </remarks>
    public async Task<APIResponse<Product>> Delete(int id)
    {
      APIResponse<Product> response = new APIResponse<Product>();
      try
      {
        var product = await _context.Products.FindAsync(id);
        if (product != null) {
          _context.Products.Remove(product);
          await _context.SaveChangesAsync();
          response.StatusCode = 200;
          response.Result = null;
        }
        else {
          response.StatusCode = 404;
          response.Message = "Product not found";
        }
      }
      catch (Exception ex)
      {
        response.StatusCode = 400;
        response.Message = ex.Message;
      }

      return response;
    }

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// </summary>
    /// <param name="id">El identificador del producto a obtener.</param>
    /// <returns>El producto especificado.</returns>
    /// <remarks>
    /// Este método obtiene un producto existente de la base de datos por su identificador. Si la operación es exitosa, el método devuelve el producto encontrado. Si la operación falla, el método devuelve un valor null.
    /// </remarks>
    public async Task<APIResponse<Product>> Get(int id)
    {
      var product = await _context.Products.FindAsync(id);

      APIResponse<Product> response = new APIResponse<Product>();
      if (product != null) response.Result = product;
      else response.StatusCode = 404; response.Message = "Product not found";

      return response;
    }

    /// <summary>
    /// Obtiene todos los productos existentes.
    /// </summary>
    /// <returns>Una lista de productos</returns>
    /// <remarks>
    /// Este método devuelve una lista de todos los productos existentes en la base de datos.
    /// </remarks>
    public async Task<List<Product>> GetAll()
    {
      return await _context.Products.ToListAsync();
    }

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    /// <param name="product">El producto a actualizar.</param>
    /// <param name="id">El identificador del producto a actualizar.</param>
    /// <returns>El producto actualizado.</returns>
    /// <remarks>
    /// Este método actualiza un producto existente de la base de datos. Si la operación es exitosa, el método devuelve el producto actualizado. Si la operación falla, el método devuelve un valor null.
    /// </remarks>
    public async Task<APIResponse<Product>> Update(Product product, int id)
    {
      APIResponse<Product> response = new APIResponse<Product>();
      try
      {
        var _product = await _context.Products.FindAsync(id);
        if (_product != null) {
          _product.Name = product.Name;
          _product.Image = product.Image;
          _product.Stock = product.Stock;
          _product.Price = product.Price;
          _product.UpdatedAt = DateTime.Now;
          await _context.SaveChangesAsync();
          response.StatusCode = 200;
          response.Result = product;
        }
        else {
          response.StatusCode = 404;
          response.Message = "Product not found";
        }
      }
      catch (Exception ex)
      {
        response.StatusCode = 400;
        response.Message = ex.Message;
      }

      return response;
    }
  }
}