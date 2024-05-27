using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniMesDocumentation.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebAppDbContext _dbContext;
        public ProductRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductEntity>> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<ProductEntity> CreateProduct(ProductEntity product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<ProductEntity> UpdateProduct(int id, ProductEntity updatedProduct)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;

            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductEntity>> GetBottomProducts(int count)
        {
            return await _dbContext.Products
                .OrderBy(p => p.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<ProductEntity>> GetTopProducts(int count)
        {
            return await _dbContext.Products
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToListAsync();
        }
    }

}