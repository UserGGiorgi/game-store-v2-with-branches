using GameStore.Web.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using GameStore.Application.Dtos.Platforms.CreatePlatform;
using GameStore.Application.Interfaces;
using GameStore.Infrastructure.Services;
using GameStore.Infrastructure.Data;
using GameStore.Application.Mapping;
using GameStore.Application.Dtos.Platforms.GetPlatform;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(typeof(CreatePlatformRequestValidator).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();


var app = builder.Build();
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
