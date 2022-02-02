using PickPoints.Core.Entities;
using System.Threading.Tasks;

namespace PickPoints.Core.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdWithPostampAsync(int id);

    }
}
