using Clean_Architecture_And_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_And_CQRS.Infrastructure.Dbcontext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
