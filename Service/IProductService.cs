using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
    public interface IProductService
    {
      Task<List<Product>> GetAll();
      Task<APIResponse<Product>> Get(int id);
      Task<APIResponse<Product>> Delete(int id);
      Task<APIResponse<Product>> Update(Product product, int id);
      Task<APIResponse<Product>> Create(Product product);
    }
}