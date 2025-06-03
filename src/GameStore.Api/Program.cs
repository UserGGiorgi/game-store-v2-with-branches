using GameStore.Web.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Infrastructure.Data;
using GameStore.Application.Mapping;
using GameStore.Application.Interfaces;
using GameStore.Infrastructure.Services;
using GameStore.Application.Services;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data.Repository;
using GameStore.Infrastructure.Data.Repositories;
using GameStore.Shared.Middleware;
using GameStore.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(typeof(CreatePlatformRequestValidator).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<TotalGamesCacheOptions>(
    builder.Configuration.GetSection(TotalGamesCacheOptions.SectionName));

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(provider => new Lazy<IGameRepository>(
    () => provider.GetRequiredService<IGameRepository>()));

builder.Services.AddScoped(provider => new Lazy<IGenreRepository>(
    () => provider.GetRequiredService<IGenreRepository>()));

builder.Services.AddScoped(provider => new Lazy<IPlatformRepository>(
    () => provider.GetRequiredService<IPlatformRepository>()));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("x-total-numbers-of-games");
    });
});

var app = builder.Build();
app.UseCors("AllowAll");

app.UseMiddleware<TotalGamesHeaderMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
