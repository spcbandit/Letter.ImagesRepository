using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
namespace Letter.Infrastructure.Application;

public static class ServiceCollection
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
        serviceCollection.AddMediatR(assembly);
    }
}