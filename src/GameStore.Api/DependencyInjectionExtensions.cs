using FluentValidation;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Facade;
using GameStore.Application.Filters.FilterIoeration;
using GameStore.Application.Filters.SortOperation;
using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using GameStore.Application.Services.Payment;
using GameStore.Domain.Constraints;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Data.Repositories;
using GameStore.Infrastructure.Data.Repository;
using GameStore.Infrastructure.Data.RepositoryCollection;
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
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IBanService, BanService>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddScoped<IPaymentProcessingService, PaymentProcessingService>();
            AddPayments(services);
            AddFiltering(services);
            AddSorting(services);
            return services;
        }
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(CreatePlatformRequestValidator).Assembly);
            services.AddScoped<IValidator<VisaPaymentRequest>, VisaPaymentRequestValidator>();
            services.AddScoped<IValidator<BoxPaymentRequest>, BoxPaymentRequestValidator>();
            services.AddScoped<IValidator<BankPaymentModel>, BankPaymentModelValidator>();
            services.AddOptions<PaymentSettings>()
              .BindConfiguration("PaymentSettings")
              .Validate(settings => settings.BankInvoiceValidityDays > 0,
              "Validity days must be positive");
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
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentBanRepository, CommentBanRepository>();

            services.AddScoped(provider => new GameRepositoryCollection(
                new Lazy<IGameRepository>(() => provider.GetRequiredService<IGameRepository>()),
                new Lazy<IGenreRepository>(() => provider.GetRequiredService<IGenreRepository>()),
                new Lazy<IPlatformRepository>(() => provider.GetRequiredService<IPlatformRepository>()),
                new Lazy<IPublisherRepository>(() => provider.GetRequiredService<IPublisherRepository>()),
                new Lazy<IOrderRepository>(() => provider.GetRequiredService<IOrderRepository>()),
                new Lazy<IGameGenreRepository>(() => provider.GetRequiredService<IGameGenreRepository>()),
                new Lazy<IGamePlatformRepository>(() => provider.GetRequiredService<IGamePlatformRepository>())
            ));
            services.AddScoped(provider => new CommentRepositoryCollection(
                new Lazy<ICommentRepository>(() => provider.GetRequiredService<ICommentRepository>()),
new Lazy<ICommentBanRepository>(() => provider.GetRequiredService<ICommentBanRepository>())
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
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddHttpClient<VisaPaymentService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(30);
            });
            return services;
        }
        private static void AddSorting(this IServiceCollection services)
        {
            services.AddTransient<ISortOperation<Game>, MostPopularSort>();
            services.AddTransient<ISortOperation<Game>, MostCommentedSort>();
            services.AddTransient<ISortOperation<Game>, PriceAscSort>();
            services.AddTransient<ISortOperation<Game>, PriceDescSort>();
            services.AddTransient<ISortOperation<Game>, NewSort>();
            services.AddTransient<ISortOperation<Game>, NameSort>();
        }
        private static void AddFiltering(this IServiceCollection services)
        {
            services.AddTransient<IFilterOperation<Game>, GenreFilter>();
            services.AddTransient<IFilterOperation<Game>, PlatformFilter>();
            services.AddTransient<IFilterOperation<Game>, PublisherFilter>();
            services.AddTransient<IFilterOperation<Game>, PriceFilter>();
            services.AddTransient<IFilterOperation<Game>, DateFilter>();
            services.AddTransient<IFilterOperation<Game>, NameFilter>();
        }
        private static void AddPayments(this IServiceCollection services)
        {
            services.AddTransient<BankPaymentService>();
            services.AddScoped<IPaymentServiceFactory, PaymentServiceFactory>();
        }
    }
}
