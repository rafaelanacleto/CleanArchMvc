using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProdutctRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;

        public ProdutctRepository(ApplicationDbContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public Task<Product> GetProductCategoryAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> RemoveAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}