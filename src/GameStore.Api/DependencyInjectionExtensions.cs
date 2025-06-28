using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using GameStore.Application.Services.Payment;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Data.Repositories;
using GameStore.Infrastructure.Data.Repository;
using GameStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPdfService, PdfService>();
            AddPayments(services);
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<GameStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IGameGenreRepository, GameGenreRepository>();
            services.AddScoped<IGamePlatformRepository, GamePlatformRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped(provider => new RepositoryCollection(
                new Lazy<IGameRepository>(() => provider.GetRequiredService<IGameRepository>()),
                new Lazy<IGenreRepository>(() => provider.GetRequiredService<IGenreRepository>()),
                new Lazy<IPlatformRepository>(() => provider.GetRequiredService<IPlatformRepository>()),
                new Lazy<IPublisherRepository>(() => provider.GetRequiredService<IPublisherRepository>()),
                new Lazy<IOrderRepository>(() => provider.GetRequiredService<IOrderRepository>()),
                new Lazy<IGameGenreRepository>(() => provider.GetRequiredService<IGameGenreRepository>()),
                new Lazy<IGamePlatformRepository>(() => provider.GetRequiredService<IGamePlatformRepository>())
            ));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddHttpClients(this IServiceCollection services,IConfiguration configuration)
        {
            var baseUrl = configuration["PaymentMicroservice:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("PaymentMicroservice BaseUrl is not configured.");

            services.AddHttpClient<BoxPaymentService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<VisaPaymentService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return services;
        }
        private static IServiceCollection AddPayments(this IServiceCollection services)
        {
            services.AddTransient<BankPaymentService>();
            services.AddScoped<IPaymentServiceFactory, PaymentServiceFactory>();
            return services;
        }
    }
}
