using ProductsResourceServer.Model.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsResourceServer.Repositories
{
    public interface IProductContext
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> createProduct(ProductDto deal);
        public Task<Product> UpdateProduct(int id, ProductDto deal);
        public Task DeleteProduct(int id);
    }
}
