using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RBTB_ServiceAccount.Application;

public static class ServiceCollection
{
    public static void AddAplication(this IServiceCollection serviceCollection)
    {
        var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
        
    }
}