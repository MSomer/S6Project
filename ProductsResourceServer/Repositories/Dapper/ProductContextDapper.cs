using Dapper;
using ProductsResourceServer.Model.Product;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsResourceServer.Repositories.Dapper
{
    public class ProductContextDapper : IProductContext
    {
        private readonly DapperContext dapperContext;

        public ProductContextDapper(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = "SELECT * FROM Products";

            using (var connection = dapperContext.CreateConnection())
            {
                var deals = await connection.QueryAsync<Product>(query);
                return deals.ToList();
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });
                return company;
            }
        }
        public async Task<Product> createProduct(ProductDto product)
        {
            var query = "INSERT INTO Products (Name, Description, Image) VALUES (@Name, @Description, @Image)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("ProductName", product.Image, DbType.Binary);

            using (var connection = dapperContext.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);

                var createdProduct = new Product
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                };
                return createdProduct;
            }
        }

        public async Task<Product> UpdateProduct(int id, ProductDto product)
        {
            var query = "UPDATE Products SET Name = @Name, Description = @Description, Image = @Image WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("ProductName", product.Image, DbType.Binary);

            using (var connection = dapperContext.CreateConnection())
            {
                var uid = await connection.ExecuteAsync(query, parameters);

                var UpdatedProduct = new Product
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                };
                return UpdatedProduct;
            }
        }

        public async Task DeleteProduct(int id)
        {
            var query = "DELETE FROM Products WHERE ID = @Id";

            using (var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
