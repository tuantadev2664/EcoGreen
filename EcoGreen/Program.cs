using System.Text;
using Application.Entities.Base;
using Application.Interface;
using Application.Interface.IRepositories;
using Application.Interface.IServices;
using Common.Middleware;
using EcoGreen.Extensions;
using EcoGreen.Helpers;
using EcoGreen.Service;
using EcoGreen.Services;
using InfrasStructure.EntityFramework.Data;
using InfrasStructure.EntityFramework.Repository;
using InfrasStructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ àáạãảâầấậẫẩăằắặẵẳèéẹẽẻêềếệễểìíịĩỉòóọõỏôồốộỗổơờớợỡởùúụũủưừứựữửỳýỵỹỷđĐ ";
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.User.RequireUniqueEmail = false;
    })
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddService();
builder.Services.AddRepository();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:Audience"],
        ValidIssuer = configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]!))
    };
});

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(options =>
    options
    .WithTitle("Movie API")
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
