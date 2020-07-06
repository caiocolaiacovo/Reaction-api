namespace Reaction_api.Application.Infrastructure.Query
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) 
            where TQuery : IQuery 
            where TResult : IResult;
    }
}