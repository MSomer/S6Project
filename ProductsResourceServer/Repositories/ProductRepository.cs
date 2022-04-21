using ProductsResourceServer.Model.Product;
using ProductsResourceServer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsResourceServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext dealContext;
        public ProductRepository(IProductContext _dealContext)
        {
            dealContext = _dealContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await dealContext.GetAllProducts();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await dealContext.GetProduct(id);
        }
        public async Task<Product> createProduct(ProductDto deal)
        {
            return await dealContext.createProduct(deal);
        }

        public async Task<Product> UpdateProduct(int id, ProductDto deal)
        {
            return await dealContext.UpdateProduct(id, deal);
        }

        public async Task DeleteProduct(int id)
        {
            await dealContext.DeleteProduct(id);
        }
    }
}
