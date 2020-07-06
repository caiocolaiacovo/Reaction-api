namespace Reaction_api.Application.Infrastructure.Query
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery, new()
        where TResult : IResult, new()
    {
        public TResult Execute(TQuery query)
        {
            TResult _queryResult;
            
            _queryResult = Handle(query);
        
            return _queryResult;
        }

        protected abstract TResult Handle(TQuery query);
    }
}