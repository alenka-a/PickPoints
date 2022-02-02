using Microsoft.EntityFrameworkCore;
using PickPoints.Core.Entities;
using PickPoints.Core.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PickPoints.Infrastructure.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(PickPointsDbContext dbContext) : base(dbContext)
        { }

        public Task<Order> GetByIdWithPostampAsync(int id)
        {
            return _dbContext.Orders
               .Include(o => o.Postamp)
               .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}