using GM.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GM.WebApi.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GMContext>(options => options.UseSqlServer(configuration.GetConnectionString("GMConnection")));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<GMContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
