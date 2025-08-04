using FluentValidation;
using GameStore.Api;
using GameStore.Api.Configuration;
using GameStore.Application.Mapping;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Data.Repositories;
using GameStore.Infrastructure.Data.Repository;
using GameStore.Shared.Configuration;
using GameStore.Shared.Middleware;
using GameStore.Web.Middleware;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigureSerilog(builder);
builder.Services.Configure<FormOptions>(options =>
{
    options.MemoryBufferThreshold = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue;
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddMemoryCache();
builder.Services.AddValidators();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClients(builder.Configuration);

builder.Services.Configure<TotalGamesCacheOptions>(
    builder.Configuration.GetSection(TotalGamesCacheOptions.SectionName));
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddServices();
builder.Services.AddRepositories(builder.Configuration);


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
