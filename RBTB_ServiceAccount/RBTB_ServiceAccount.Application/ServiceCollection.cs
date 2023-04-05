using Microsoft.Extensions.DependencyInjection;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Services;

namespace RBTB_ServiceAccount.Application;

public static class ServiceCollection
{
    public static void AddAplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ITradesService, TradesService>();

        serviceCollection.AddSingleton<IWalletService, WalletService>();

        serviceCollection.AddSingleton<IPositionsService, PositionsService>();
    }
}