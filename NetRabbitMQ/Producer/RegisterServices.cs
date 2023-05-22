using Microsoft.EntityFrameworkCore;

namespace Producer
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            {
                //options.UseSqlServer();
                options.UseInMemoryDatabase(configuration.GetConnectionString("OrderDbContext"));
            });
            services.AddScoped<IOrderRespository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
