using FluentValidation;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Facade;
using GameStore.Application.Filters.FilterIoeration;
using GameStore.Application.Filters.SortOperation;
using GameStore.Application.Interfaces.Auth;
using GameStore.Application.Interfaces.Comments;
using GameStore.Application.Interfaces.Games;
using GameStore.Application.Interfaces.Orders;
using GameStore.Application.Interfaces.Payment;
using GameStore.Application.Interfaces.Pdf;
using GameStore.Application.Services.Auth;
using GameStore.Application.Services.Games;
using GameStore.Application.Services.Orders;
using GameStore.Application.Services.Payment;
using GameStore.Application.Services.Pdf;
using GameStore.Domain.Constraints;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories.Auth;
using GameStore.Domain.Interfaces.Repositories.Comments;
using GameStore.Domain.Interfaces.Repositories.Games;
using GameStore.Domain.Interfaces.Repositories.Orders;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Data.Repository.Auth;
using GameStore.Infrastructure.Data.Repository.Comments;
using GameStore.Infrastructure.Data.Repository.Games;
using GameStore.Infrastructure.Data.Repository.Orders;
using GameStore.Infrastructure.Data.RepositoryCollection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog.Events;
using Serilog;
using System.Security.Claims;
using System.Text;
using GameStore.Application.Services.Comments;

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
        public static IServiceCollection AddFrontEnd(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    builder => builder
                        .WithOrigins("http://localhost:8080", "http://127.0.0.1:8080", "http://192.168.100.2:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("x-total-numbers-of-games")
                );
            });
            return services;
        }
        public static void SerilogConfiguretion(this WebApplicationBuilder builder)
        {
            var logPath = Path.Combine(builder.Environment.ContentRootPath, "Logs");
            Directory.CreateDirectory(logPath);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()

                .WriteTo.File(
                    Path.Combine(logPath, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

                .WriteTo.File(
                    Path.Combine(logPath, "errors-.txt"),
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            builder.Host.UseSerilog();
        }

        public static IServiceCollection AddAuthorizationExtension(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();

                var permissions = dbContext.Permissions
                    .AsNoTracking()
                    .Select(p => p.Name)
                    .ToList();

                foreach (var permission in permissions)
                {
                    options.AddPolicy(permission, policy =>
                        policy.RequireClaim("Permission", permission));
                }

                options.AddPolicy("Admin", policy =>
                    policy.RequireRole("Admin")
                          .RequireClaim("Permission", "ManageUsers"));
            });

            return services;
        }
        public static IServiceCollection AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameStore API", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                     {
                      new OpenApiSecurityScheme
                     {
                      Reference = new OpenApiReference
                     {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                      }
                      },
                       new string[] {}
                    }
                 });
            });
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
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
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
            services.AddScoped<IOrderGameRepository,OrderGameRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();

            services.AddScoped(provider => new GameRepositoryCollection(
                new Lazy<IGameRepository>(() => provider.GetRequiredService<IGameRepository>()),
                new Lazy<IGenreRepository>(() => provider.GetRequiredService<IGenreRepository>()),
                new Lazy<IPlatformRepository>(() => provider.GetRequiredService<IPlatformRepository>()),
                new Lazy<IOrderRepository>(() => provider.GetRequiredService<IOrderRepository>()),
                new Lazy<IGameGenreRepository>(() => provider.GetRequiredService<IGameGenreRepository>()),
                new Lazy<IGamePlatformRepository>(() => provider.GetRequiredService<IGamePlatformRepository>()),
                new Lazy<IOrderGameRepository>(() => provider.GetRequiredService<IOrderGameRepository>())
            ));

            services.AddScoped(provider => new CommentRepositoryCollection(
                new Lazy<ICommentRepository>(() => provider.GetRequiredService<ICommentRepository>()),
                new Lazy<ICommentBanRepository>(() => provider.GetRequiredService<ICommentBanRepository>()),
                new Lazy<IPublisherRepository>(() => provider.GetRequiredService<IPublisherRepository>())

            ));
            services.AddScoped(provider => new AuthRepositoryCollection(
                new Lazy<IRoleRepository>(() => provider.GetRequiredService<IRoleRepository>()),
                new Lazy<IPermissionRepository>(() => provider.GetRequiredService<IPermissionRepository>()),
                new Lazy<IRolePermissionRepository>(() => provider.GetRequiredService<IRolePermissionRepository>()),
                new Lazy<IApplicationUserRepository>(() => provider.GetRequiredService<IApplicationUserRepository>()),
                new Lazy<IUserRoleRepository>(() => provider.GetRequiredService<IUserRoleRepository>())
            ));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddAllHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPaymentHttpClients(configuration);
            services.AddAuthHttpClients(configuration);
            return services;
        }
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["AuthorizationMicroservice:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("PaymentMicroservice BaseUrl is not configured.");

            var Key = configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(Key))
                throw new InvalidOperationException("JWT Key is not configured");

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddHttpClient("ExternalAuth", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Key)),
                        RoleClaimType = ClaimTypes.Role,
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                    options.MapInboundClaims = false;
                });
            return services;
        }



        private static void AddPaymentHttpClients(this IServiceCollection services, IConfiguration configuration)
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
        }
        private static void AddAuthHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var authBaseUrl = configuration["AuthorizationMicroservice:BaseUrl"];
            if (string.IsNullOrWhiteSpace(authBaseUrl))
                throw new InvalidOperationException("AuthorizationMicroservice BaseUrl is not configured.");

            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri(authBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddHttpClient("ExternalAuth", client =>
            {
                client.BaseAddress = new Uri(authBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(30);
            });
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
