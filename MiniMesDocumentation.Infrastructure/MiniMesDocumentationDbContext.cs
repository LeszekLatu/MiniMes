using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniMesDocumentation.Infrastructure
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {
        }
        public DbSet<MachineEntity> Machines { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ParameterEntity> Parameters { get; set; }
        public DbSet<ParameterValueEntity> ParameterValues { get; set; }
        public DbSet<ProcessEntity> Proceses { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

    }
}