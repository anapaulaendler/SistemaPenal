using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
}