using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
  public class ProductService : IProductService
  {
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
      _context = context;
    }

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

    public async Task<APIResponse<Product>> Get(int id)
    {
      var product = await _context.Products.FindAsync(id);

      APIResponse<Product> response = new APIResponse<Product>();
      if (product != null) response.Result = product;
      else response.StatusCode = 404; response.Message = "Product not found";

      return response;
    }

    public async Task<List<Product>> GetAll()
    {
      return await _context.Products.ToListAsync();
    }

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