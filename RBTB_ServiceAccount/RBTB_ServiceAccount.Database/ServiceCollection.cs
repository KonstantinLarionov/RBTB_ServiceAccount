using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Database.Abstractions;
using RBTB_ServiceAccount.Database.Repositories;

namespace RBTB_ServiceAccount.Database;

public static class ServiceCollection
{
    public static void AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<RBTB_Context>(
            options => options.UseNpgsql(configuration.GetConnectionString("DbConnection")), ServiceLifetime.Singleton);
        service.AddTransient<IRepository<Positions>, PositionsRepository>();
        service.AddTransient<IRepository<Trades>, TradesRepository>();
        service.AddTransient<IRepository<Users>, UsersRepository>();
        service.AddTransient<IRepository<Wallet>, WalletRepository>();

    }
}