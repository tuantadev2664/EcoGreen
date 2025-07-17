using Common.Middleware;
using EcoGreen.Extensions;
using EcoGreen.Helpers;
using InfrasStructure.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// var envPath = Path.Combine("..", ".env");
// DotNetEnv.Env.Load(envPath);

// Add services to the container.
configuration.AddEnvironmentVariables();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.MaxDepth = 128;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddService();
builder.Services.AddRepository();
builder.Services.AddAuthenticationServices(configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    );
});

builder.WebHost.UseUrls("http://0.0.0.0:8080");


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Thêm vào pipeline
app.UseCors("AllowFrontend");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(options =>
    options
    .WithTitle("EcoGreen API")
    .WithTheme(ScalarTheme.BluePlanet)
    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
    );
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
