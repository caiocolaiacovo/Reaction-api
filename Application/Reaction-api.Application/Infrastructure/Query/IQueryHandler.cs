namespace Reaction_api.Application.Infrastructure.Query
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Execute(TQuery query);
    }
}