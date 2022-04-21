using ResourceServer.Model.Deal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceServer.Repositories
{
    public interface IDealContext
    {
        public Task<IEnumerable<Deal>> GetAllDeals();
        public Task<Deal> GetDeal(int id);
        public Task<Deal> createDeal(DealDto deal);
        public Task<Deal> UpdateDeal(int id, DealDto deal);
        public Task DeleteDeal(int id);
    }
}
