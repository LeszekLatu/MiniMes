using Microsoft.AspNetCore.Mvc;
using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using MiniMesDocumentation.Infrastructure.Repositories;

namespace MiniMesDocumentation.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Get All Orders
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        // Create Order
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<OrderEntity>> CreateOrder(OrderEntity order)
        {
            var createdOrder = await _orderRepository.CreateOrder(order);
            return CreatedAtAction(nameof(CreateOrder), new { id = createdOrder.Id }, createdOrder);
        }

        // Update Order
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<OrderEntity>> UpdateOrder(int id, OrderEntity updatedOrder)
        {
            var order = await _orderRepository.UpdateOrder(id, updatedOrder);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // Delete Order
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteOrder(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get Bottom Orders
        [HttpGet]
        [Route("GetBottom/{count}")]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetBottomOrders(int count)
        {
            var orders = await _orderRepository.GetBottomOrders(count);
            return Ok(orders);
        }

        // Get Top Orders
        [HttpGet]
        [Route("GetTop/{count}")]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetTopOrders(int count)
        {
            var orders = await _orderRepository.GetTopOrders(count);
            return Ok(orders);
        }
    }

}
