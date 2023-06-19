using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RBTB_ServiceAccount.Application;

public static class ServiceCollection
{
    public static void AddApplication(this IServiceCollection services )
    {
        var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
        services.AddMediatR(assembly);
    }
}