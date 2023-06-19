using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBTB_ServiceAccount.Database.Entities;
using RBTB_ServiceAccount.Database.Repositories;

namespace RBTB_ServiceAccount.Database;

public static class ServiceCollection
{
    public static void AddInfrastructureDataBase( this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ServiceAccountContext>( options =>
                options.UseMySql( configuration.GetConnectionString( "DBConnection" ),
                new MySqlServerVersion( new Version( 5, 6, 45 ) ) ) );

        services.AddTransient<IRepository<PositionEntity>, PositionsRepository>();
        services.AddTransient<IRepository<TradeEntity>, TradesRepository>();
        services.AddTransient<IRepository<UserEntity>, UsersRepository>();
        services.AddTransient<IRepository<WalletEntity>, WalletRepository>();
    }
}