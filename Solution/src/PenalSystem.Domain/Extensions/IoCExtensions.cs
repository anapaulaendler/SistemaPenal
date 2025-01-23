using Library.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Domain.Services;

namespace PenalSystem.Domain.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        JwtConfigurations(services, configuration);
        RegisterServices(services);
        RegisterAutoMappers(services);

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IStudyService, StudyService>();
        services.AddScoped<IWorkDayService, WorkDayService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPrisonerService, PrisonerService>();

        return services;
    }

    public static IServiceCollection RegisterAutoMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BookService).Assembly);
        services.AddAutoMapper(typeof(EmployeeService).Assembly);
        services.AddAutoMapper(typeof(PrisonerService).Assembly);
        services.AddAutoMapper(typeof(StudyService).Assembly);
        services.AddAutoMapper(typeof(WorkDayService).Assembly);

        return services;
    }

    public static IServiceCollection JwtConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        return services;
    }
}