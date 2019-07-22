using System.Collections.Generic;
using Reaction_api.Application.Infrastructure;
using Reaction_api.Domain;

namespace Reaction_api.Application.Query.Moments
{
    public class AllMomentsQueryResult : IResult
    {
        public IEnumerable<Moment> Moments { get; set; }

        public AllMomentsQueryResult()
        {
            
        }
    }
}