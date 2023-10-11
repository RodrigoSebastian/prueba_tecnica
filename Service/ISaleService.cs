using PruebaTecnica.Helper;
using PruebaTecnica.Model;

namespace PruebaTecnica.Service
{
    public interface ISaleService
    {
      Task<List<Sale>> GetAll();
      Task<APIResponse<Sale>> Get(int id);
      Task<APIResponse<Sale>> Create(List<SaleParams> saleParams);
    }
}