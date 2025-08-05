using GameStore.Api;
using GameStore.Application.Mapping;
using GameStore.Shared.Configuration;
using GameStore.Shared.Middleware;
using GameStore.Web.Middleware;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.SerilogConfiguretion();
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
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenExtension();

builder.Services.AddAllHttpClients(builder.Configuration);

builder.Services.Configure<TotalGamesCacheOptions>(
    builder.Configuration.GetSection(TotalGamesCacheOptions.SectionName));
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddServices();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddAuthorizationExtension();
builder.Services.AddFrontEnd();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
