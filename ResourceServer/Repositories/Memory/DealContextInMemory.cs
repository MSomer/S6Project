using ResourceServer.Model.Deal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceServer.Repositories.Memory
{
    public class DealContextInMemory : IDealContext
    {
        public Task<Deal> createDeal(DealDto deal)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteDeal(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Deal>> GetAllDeals()
        {
            throw new System.NotImplementedException();
        }

        public Task<Deal> GetDeal(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Deal> UpdateDeal(int id, DealDto deal)
        {
            throw new System.NotImplementedException();
        }
    }
}
