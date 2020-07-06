using System.Collections.Generic;
using Reaction_api.Application.Infrastructure;
using Reaction_api.Application.Infrastructure.Query;
using Reaction_api.Domain;

namespace Reaction_api.Application.Query.Moments
{
    public class AllMomentsQueryHandler : QueryHandler<AllMomentsQuery, AllMomentsQueryResult>
    {
        public readonly IRepository<Moment> _repository;

        public AllMomentsQueryHandler(IRepository<Moment> repository)
        {
            _repository = repository;
        }

        protected override AllMomentsQueryResult Handle(AllMomentsQuery query)
        {
            var result = new AllMomentsQueryResult {
                Moments = _repository.Get()
            };
            
            return result;
        }
    }
}