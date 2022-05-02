using API.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions;

public static class ApplicationServicesExtension
{
    public static void AddApplicationServices(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<StoreContext>(
            x => x.UseSqlite(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddAutoMapper(typeof(MappingProfiles));
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>),
            typeof(GenericRepository<>));
    }
}