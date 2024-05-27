using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniMesDocumentation.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WebAppDbContext _dbContext;
        public OrderRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OrderEntity>> GetAllOrders()
        {
            var Order = await _dbContext.Orders.ToListAsync();
            return Order.Cast<OrderEntity>().ToList();
        }

        public async Task<OrderEntity> CreateOrder(OrderEntity order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<OrderEntity> UpdateOrder(int id, OrderEntity updatedOrder)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }

            order.Code = updatedOrder.Code;
            order.MachineId = updatedOrder.MachineId;
            order.ProductId = updatedOrder.ProductId;
            order.Quantity = updatedOrder.Quantity;

            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderEntity>> GetBottomOrders(int count)
        {
            return await _dbContext.Orders
                .OrderBy(o => o.Quantity)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<OrderEntity>> GetTopOrders(int count)
        {
            return await _dbContext.Orders
                .OrderByDescending(o => o.Quantity)
                .Take(count)
                .ToListAsync();
        }

    }
}