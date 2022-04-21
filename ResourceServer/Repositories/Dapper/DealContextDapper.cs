using Dapper;
using ResourceServer.Model.Deal;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Repositories.Dapper
{
    public class DealContextDapper : IDealContext
    {
        private readonly DapperContext dapperContext;

        public DealContextDapper(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<IEnumerable<Deal>> GetAllDeals()
        {
            var query = "SELECT * FROM Deals";

            using (var connection = dapperContext.CreateConnection())
            {
                var deals = await connection.QueryAsync<Deal>(query);
                return deals.ToList();
            }
        }

        public async Task<Deal> GetDeal(int id)
        {
            var query = "SELECT * FROM Deals WHERE Id = @Id";
            using (var connection = dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Deal>(query, new { id });
                return company;
            }
        }
        public async Task<Deal> createDeal(DealDto deal)
        {
            var query = "INSERT INTO Deals (ProductId, Name, Description, ProductName, OldPrice, NewPrice, ProductLink, Timestamp) VALUES (@ProductId, @Name, @Description, @ProductName, @OldPrice, @NewPrice, @ProductLink, @Timestamp)";
            
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", deal.ProductId, DbType.Int64);
            parameters.Add("Name", deal.Name, DbType.String);
            parameters.Add("Description", deal.Description, DbType.String);
            parameters.Add("ProductName", deal.ProductName, DbType.String);
            parameters.Add("OldPrice", deal.OldPrice, DbType.Int64);
            parameters.Add("NewPrice", deal.NewPrice, DbType.Int64);
            parameters.Add("ProductLink", deal.ProductLink, DbType.String);
            parameters.Add("Timestamp", deal.Timestamp, DbType.String);

            using (var connection = dapperContext.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);

                var createdDeal = new Deal
                {
                    Id = id,
                    Name = deal.Name,
                    Description = deal.Description,
                    ProductName = deal.ProductName,
                    OldPrice = deal.OldPrice,
                    NewPrice = deal.NewPrice,
                    ProductLink = deal.ProductLink,
                    Timestamp = deal.Timestamp,
                };
                return createdDeal;
            }
        }

        public async Task<Deal> UpdateDeal(int id, DealDto deal)
        {
            var query = "UPDATE Deals SET ProductId = @ProductId, Name = @Name, Description = @Description, ProductName = @ProductName, OldPrice = @OldPrice, NewPrice = @NewPrice, ProductLink = @ProductLink, Timestamp = @Timestamp WHERE Id = @Id";
            
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", deal.ProductId, DbType.Int64);
            parameters.Add("Name", deal.Name, DbType.String);
            parameters.Add("Description", deal.Description, DbType.String);
            parameters.Add("ProductName", deal.ProductName, DbType.String);
            parameters.Add("OldPrice", deal.OldPrice, DbType.Int64);
            parameters.Add("NewPrice", deal.NewPrice, DbType.Int64);
            parameters.Add("ProductLink", deal.ProductLink, DbType.String);
            parameters.Add("Timestamp", deal.Timestamp, DbType.String);

            using (var connection = dapperContext.CreateConnection())
            {
                var uid = await connection.ExecuteAsync(query, parameters);

                var UpdatedDeal = new Deal
                {
                    Id = uid,
                    Name = deal.Name,
                    Description = deal.Description,
                    ProductName = deal.ProductName,
                    OldPrice = deal.OldPrice,
                    NewPrice = deal.NewPrice,
                    ProductLink = deal.ProductLink,
                    Timestamp = deal.Timestamp,
                };
                return UpdatedDeal;
            }
        }

        public async Task DeleteDeal(int id)
        {
            var query = "DELETE FROM Deals WHERE ID = @Id";

            using (var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
