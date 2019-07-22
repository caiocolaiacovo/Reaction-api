using Microsoft.Extensions.DependencyInjection;
using Reaction_api.Application.Infrastructure;
using Reaction_api.Application.Infrastructure.Query;
using Reaction_api.Application.Query.Moments;
using Reaction_api.Domain;
using Reaction_api.Infra.Data;

namespace Reaction_api.Infra.CrossCutting.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IQueryDispatcher), typeof(QueryDispatcher));
            services.AddScoped(typeof(IQueryHandler<AllMomentsQuery, AllMomentsQueryResult>), typeof(AllMomentsQueryHandler));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}