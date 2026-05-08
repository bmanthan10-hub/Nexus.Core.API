using Nexus.Core.API.Models;
using Nexus.Core.API.Repositories;
using Nexus.Core.API.Exceptions;

namespace Nexus.Core.API.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new ProductNotFoundException(id);

            return product;
        }
    }
}