using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Services.Repositories;
using RentACar.Persistance.Contexts;
using RentACar.Persistance.Repositories;

namespace RentACar.Persistance;
public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseInMemoryDatabase("narchitecture");
        });

        services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }
}
