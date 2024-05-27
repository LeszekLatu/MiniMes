using MiniMesDocumentation.Domain.Entities;

namespace MiniMesDocumentation.Application.Contracts
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllProducts();
        Task<ProductEntity> CreateProduct(ProductEntity product);
        Task<ProductEntity> UpdateProduct(int id, ProductEntity updatedProduct);
        Task<bool> DeleteProduct(int id);
        Task<List<ProductEntity>> GetBottomProducts(int count);
        Task<List<ProductEntity>> GetTopProducts(int count);
    }

}
