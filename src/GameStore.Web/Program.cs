using GameStore.Application.Interfaces;
using GameStore.Application.Mapping;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using GameStore.Web.Filters;
using GameStore.Web.Logger;
using GameStore.Web.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var logPath = Path.Combine(builder.Environment.ContentRootPath, "Logs");
builder.Logging.AddProvider(new FileLoggerProvider(logPath));

builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMemoryCache();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPdfService,PdfService>();
builder.Services.AddScoped<IPaymentMicroservice, MockPaymentMicroservice>();
builder.Services.AddScoped<IBanService, BanService>();
builder.Services.AddScoped<TotalGamesHeaderFilter>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameStore API", Version = "v1" });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<TotalGamesHeaderFilter>();
});

builder.Services.AddCors(options => {
    options.AddPolicy("UI", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithExposedHeaders("x-total-numbers-of-games"));
});

builder.Services.AddCors(options => {
    options.AddPolicy("UI", policy =>
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithExposedHeaders("x-total-numbers-of-games"));
});

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameStore API v1"));
}
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

    logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");

    var stopwatch = Stopwatch.StartNew();
    await next();
    stopwatch.Stop();

    logger.LogInformation($"Request Completed: {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");
});

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (exceptionHandlerFeature?.Error != null)
        {
            logger.LogError(
                exceptionHandlerFeature.Error,
                "Unhandled exception occurred: {Method} {Path}",
                context.Request.Method,
                context.Request.Path
            );
        }
        else
        {
            logger.LogError(
                "Unknown error occurred: {Method} {Path}",
                context.Request.Method,
                context.Request.Path
            );
        }

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Internal Server Error");
    });
});
app.UseCors("UI");
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
