using System;

namespace Reaction_api.Application.Infrastructure.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public IServiceProvider ServiceProvider { get; }

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public TResult Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult : IResult
        {
            var handler = (IQueryHandler<TQuery, TResult>)ServiceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>));

            return handler.Execute(query);    
        }
    }
}