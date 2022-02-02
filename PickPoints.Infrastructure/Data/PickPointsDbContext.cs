using Microsoft.EntityFrameworkCore;
using PickPoints.Core.Entities;
using System.Collections.Generic;

namespace PickPoints.Infrastructure.Data
{
    public class PickPointsDbContext : DbContext
    {
        public DbSet<Postamp> Postamps { get; set; }

        public DbSet<Order> Orders { get; set; }

        public PickPointsDbContext(DbContextOptions<PickPointsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Postamp>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasIndex(x => x.Number).IsUnique();
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(x => x.Id);            
            });

            SeedPostams(modelBuilder);
        }

        private void SeedPostams(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Postamp>().HasData(
                new List<Postamp>()
            {
                    new Postamp(){Id = 1, Number = "1111-111", Address = "Авиаторов, улица 30", IsActive = true },
                    new Postamp(){Id = 2, Number = "2222-222", Address = "Авиаторов, улица 30", IsActive = true },
                    new Postamp(){Id = 3, Number = "3333-333", Address = "Авиаторов, улица 30", IsActive = false },
            });
        }
    }
}
