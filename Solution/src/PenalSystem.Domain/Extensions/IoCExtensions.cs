using Microsoft.Extensions.DependencyInjection;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Domain.Services;

namespace PenalSystem.Domain.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection Register(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IStudyService, StudyService>();
        services.AddScoped<IWorkDayService, WorkDayService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPrisonerService, PrisonerService>();

        // services.AddAutoMapper([typeof(BookService).Assembly]);

        return services;
    }
}