using FluentValidation;
using GameStore.Api;
using GameStore.Api.Configuration;
using GameStore.Application.Dtos.Order.PaymentRequest;
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
