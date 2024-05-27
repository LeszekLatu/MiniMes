using MiniMesDocumentation.Domain.Entities;

namespace MiniMesDocumentation.Application.Contracts
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetAllOrders();
        Task<OrderEntity> CreateOrder(OrderEntity order);
        Task<OrderEntity> UpdateOrder(int id, OrderEntity updatedOrder);
        Task<bool> DeleteOrder(int id);
        Task<List<OrderEntity>> GetBottomOrders(int count);
        Task<List<OrderEntity>> GetTopOrders(int count);
    }

}