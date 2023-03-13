using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RBTB_ServiceAccount.Database;

public static class ServiceCollection
{
    public static void AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<RBTB_Context>(
            options => options.UseNpgsql(configuration.GetConnectionString("DbConnection")), ServiceLifetime.Singleton);
    }
}