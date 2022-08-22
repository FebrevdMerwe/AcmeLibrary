using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeLibrary.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookInMemoryRepository>();
            services.AddScoped<IClientRepository, ClientInMemoryRepository>();
            return services;
        }
    }
}
