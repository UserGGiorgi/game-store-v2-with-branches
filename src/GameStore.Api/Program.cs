using FluentValidation;
using GameStore.Api.Configuration;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Application.Mapping;
using GameStore.Application.Services;
using GameStore.Application.Services.Payment;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Data.Repositories;
using GameStore.Infrastructure.Data.Repository;
using GameStore.Infrastructure.Services;
using GameStore.Shared.Configuration;
using GameStore.Shared.Middleware;
using GameStore.Web.Middleware;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigureSerilog(builder);
builder.Services.Configure<FormOptions>(options =>
{
    options.MemoryBufferThreshold = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue;
});
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(typeof(CreatePlatformRequestValidator).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var baseUrl = builder.Configuration["PaymentMicroservice:BaseUrl"];
if (string.IsNullOrWhiteSpace(baseUrl))
    throw new InvalidOperationException("PaymentMicroservice BaseUrl is not configured.");

builder.Services.AddHttpClient <IBoxPaymentService > (client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<VisaPaymentService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.Configure<TotalGamesCacheOptions>(
    builder.Configuration.GetSection(TotalGamesCacheOptions.SectionName));

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IGameGenreRepository, GameGenreRepository>();
builder.Services.AddScoped<IGamePlatformRepository, GamePlatformRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<BankPaymentService>();
builder.Services.AddSingleton<IPaymentServiceFactory, PaymentServiceFactory>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(provider => new Lazy<IGameRepository>(
    () => provider.GetRequiredService<IGameRepository>()));

builder.Services.AddScoped(provider => new Lazy<IGenreRepository>(
    () => provider.GetRequiredService<IGenreRepository>()));

builder.Services.AddScoped(provider => new Lazy<IPlatformRepository>(
    () => provider.GetRequiredService<IPlatformRepository>()));

builder.Services.AddScoped(provider => new Lazy<IPublisherRepository>(
    () => provider.GetRequiredService<IPublisherRepository>()));

builder.Services.AddScoped(provider => new Lazy<IGameGenreRepository>(
    () => provider.GetRequiredService<IGameGenreRepository>()));

builder.Services.AddScoped(provider => new Lazy<IGamePlatformRepository>(
    () => provider.GetRequiredService<IGamePlatformRepository>()));

builder.Services.AddScoped(provider => new Lazy<IOrderRepository>(
    () => provider.GetRequiredService<IOrderRepository>()));
//for angularr
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:8080") //http-server port
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithExposedHeaders("x-total-numbers-of-games")
    );
});

var app = builder.Build();
app.UseHttpsRedirection(); 
app.UseCors("AllowFrontend");

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<TotalGamesHeaderMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
