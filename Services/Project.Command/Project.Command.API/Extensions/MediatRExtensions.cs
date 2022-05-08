using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Project.Command.Application.Common.Interfaces;

namespace Project.API.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommandResult).Assembly);
            return services;
        }
    }
}
