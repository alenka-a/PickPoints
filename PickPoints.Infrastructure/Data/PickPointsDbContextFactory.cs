using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PickPoints.Infrastructure.Data
{
    public class PickPointsDbContextFactory : IDesignTimeDbContextFactory<PickPointsDbContext>
    {
        public PickPointsDbContext CreateDbContext(string[] args)
        {          
            // TODO Заполнить для создания миграций
            var connectionString = "";
            var builder = new DbContextOptionsBuilder<PickPointsDbContext>();
            builder.UseNpgsql(connectionString);

            return new PickPointsDbContext(builder.Options);
        }
    }
}
