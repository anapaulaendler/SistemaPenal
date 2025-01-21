using DomainIoC = PenalSystem.Domain.Extensions.IoCExtensions;
using DataIoC = PenalSystem.Infra.Data.Extensions.IoCExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PenalSystem.Infra.CrossCutting.IoC;

public static class DependencyInjectionBootstrap
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        DomainIoC.Register(services);
        DataIoC.Register(services, configuration);

        return services;
    }
}
