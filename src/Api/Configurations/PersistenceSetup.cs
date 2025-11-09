using Application.Auth;
using Domain.Auth.Interfaces;
using Infrastructure;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Api.Configurations;

public static class PersistenceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ISession, Session>();
        services.AddHostedService<ApplicationDbInitializer>();
        services.AddDbContextPool<ApplicationDbContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            o.UseExceptionProcessor();
        });

        return services;
    }
}