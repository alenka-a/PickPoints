using Microsoft.AspNetCore.Mvc;
using PickPoints.Core.Models;
using PickPoints.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace PickPoints.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrdersService _orderService;
        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            return Ok(order);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest model)
        {
            var orderId = await _orderService.CreateOrder(model);
            var result = new { id = orderId };
            return new CreatedResult(Url.RouteUrl("GetOrder", result, Url.ActionContext.HttpContext.Request.Scheme), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderRequest model)
        {
            await _orderService.UpdateOrder(id, model);
            return Ok();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            await _orderService.CancelOrder(id);
            return Ok();
        }
    }
}
