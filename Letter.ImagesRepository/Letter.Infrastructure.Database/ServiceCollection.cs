using Letter.Infrastructure.Application.Domains.Abstractions;
using Letter.Infrastructure.Application.Domains.Entities;
using Letter.Infrastructure.Database.Context;
using Letter.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Letter.Infrastructure.Database;

public static class ServiceCollection
{
    public static void AddInfrastructureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<ImageContext>(options => options.UseMySql(
            configuration.GetConnectionString("DBConnection"),
            new MySqlServerVersion(new Version(5, 6, 45))));
        services.AddTransient<IRepository<Image>, ImagesRepository>();
    }
}