using System.Text;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Infra.Context;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories;

namespace PenalSystem.Infra.Data.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddUnitOfWork(services);
        AddContext(services, configuration);
        AddAuthenticationAndAuthorization(services, configuration);

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IWorkDayRepository, WorkDayRepository>();
        services.AddScoped<IStudyRepository, StudyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPrisonerRepository, PrisonerRepository>();

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, AppUnitOfWork>();

        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlite(configuration.GetConnectionString(nameof(AppDbContext))));

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

        if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Secret))
        {
            throw new ArgumentNullException(nameof(jwtSettings.Secret), "JwtSettings or Key cannot be null");
        }

        var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        return services;
    }
}