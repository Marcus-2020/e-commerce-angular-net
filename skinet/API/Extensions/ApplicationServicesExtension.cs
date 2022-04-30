using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServicesExtension
{
    public static void AddApplicationServices(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<StoreContext>(
            x => x.UseSqlite(
                configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}