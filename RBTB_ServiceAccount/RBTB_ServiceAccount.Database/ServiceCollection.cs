using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;
using RBTB_ServiceAccount.Database.Repositories;

namespace RBTB_ServiceAccount.Database;

public static class ServiceCollection
{
    public static void AddInfrastructureDataBase( this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ServiceAccountContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DbConnection")), ServiceLifetime.Singleton);

        service.AddTransient<IRepository<PositionEntity>, PositionsRepository>();
        service.AddTransient<IRepository<TradeEntity>, TradesRepository>();
        service.AddTransient<IRepository<UserEntity>, UsersRepository>();
        service.AddTransient<IRepository<WalletEntity>, WalletRepository>();
    }
}