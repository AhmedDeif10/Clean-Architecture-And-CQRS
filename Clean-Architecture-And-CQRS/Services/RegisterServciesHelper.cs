using Clean_Architecture_And_CQRS.Application.Products.Commands;
using Clean_Architecture_And_CQRS.Application.Products.RepositoryInterface;
using Clean_Architecture_And_CQRS.Infrastructure.Dbcontext;
using Clean_Architecture_And_CQRS.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_And_CQRS.Services
{
    public class RegisterServciesHelper
    {
        public static void RegisteredServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
