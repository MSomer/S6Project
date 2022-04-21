using ResourceServer.Model.Deal;
using ResourceServer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceServer.Repositories
{
    public class DealRepository : IDealRepository
    {
        private readonly IDealContext dealContext;
        public DealRepository(IDealContext _dealContext)
        {
            dealContext = _dealContext;
        }

        public async Task<IEnumerable<Deal>> GetAllDeals()
        {
            return await dealContext.GetAllDeals();
        }

        public async Task<Deal> GetDeal(int id)
        {
            return await dealContext.GetDeal(id);
        }
        public async Task<Deal> createDeal(DealDto deal)
        {
            return await dealContext.createDeal(deal);
        }

        public async Task<Deal> UpdateDeal(int id, DealDto deal)
        {
            return await dealContext.UpdateDeal(id, deal);
        }

        public async Task DeleteDeal(int id)
        {
            await dealContext.DeleteDeal(id);
        }
    }
}
