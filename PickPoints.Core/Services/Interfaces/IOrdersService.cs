using PickPoints.Core.Models;
using System.Threading.Tasks;

namespace PickPoints.Core.Services.Interfaces
{
    public interface IOrdersService
    {
        Task CancelOrder(int id);
        Task<int> CreateOrder(CreateOrderRequest model);
        Task<OrderResponse> GetOrder(int id);
        Task UpdateOrder(int id, UpdateOrderRequest model);
    }
}