using Microsoft.EntityFrameworkCore;
using XptoAPI.Models;

namespace XptoAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> clients { get; set; }
        public DbSet<ServiceExecuter> serviceExecuters { get; set; }
        public DbSet<ServiceOrder> serviceOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceOrder>()
                .HasOne(so => so.Client)
                .WithMany(c => c.ServiceOrders)
                .HasForeignKey(so => so.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServiceOrder>()
                .HasOne(so => so.ServiceExecuter)
                .WithMany(se => se.ServiceOrders)
                .HasForeignKey(so => so.ServiceExecuterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
