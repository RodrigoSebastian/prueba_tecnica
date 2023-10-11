using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
  public class SaleService : ISaleService
  {
    private readonly DataContext _context;

    public SaleService(DataContext context)
    {
      _context = context;
    }

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

          var saleDetail = new SaleDetail();
          saleDetail.IdProduct = product.Id;
          saleDetail.Amount = saleParam.Amount;
          saleDetail.SubTotal = product.Price * saleParam.Amount;

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

    public async Task<APIResponse<Sale>> Get(int id)
    {
      var sale = await _context.Sales.Include(sale => sale.SaleDetails).FirstOrDefaultAsync(sale => sale.Id == id);

      APIResponse<Sale> response = new APIResponse<Sale>();
      if (sale != null) response.Result = sale;
      else response.StatusCode = 404; response.Message = "Sale not found";

      return response;
    }

    public async Task<List<Sale>> GetAll()
    {
      return await _context.Sales.Include(sale => sale.SaleDetails).ToListAsync();
    }
  }
}