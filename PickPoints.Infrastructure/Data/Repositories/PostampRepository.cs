using PickPoints.Core.Entities;
using PickPoints.Core.Repositories.Interfaces;

namespace PickPoints.Infrastructure.Data.Repositories
{
    public class PostampRepository : BaseRepository<Postamp>, IPostampRepository
    {

        public PostampRepository(PickPointsDbContext dbContext) : base(dbContext)
        { }
    }
}
