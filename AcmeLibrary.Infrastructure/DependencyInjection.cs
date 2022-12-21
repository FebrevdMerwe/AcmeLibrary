using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Application.Interfaces.Services;
using AcmeLibrary.Infrastructure.Persistence;
using AcmeLibrary.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeLibrary.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookInMemoryRepository>();
            services.AddScoped<IBorrowedBooksRepository, BorrowedBooksInMemoryRepository>();
            services.AddScoped<IClientRepository, ClientInMemoryRepository>();
            services.AddScoped<IIsbnService, IsbnService>();

            services.AddPersistance();

            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)
        {
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            return services;
        }
    }
}
