using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reaction_api.Application.Infrastructure.Query;
using Reaction_api.Application.Query.Moments;
using Reaction_api.Domain;

namespace API.Controllers
{
    [Route ("api/moments")]
    public class MomentsController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public MomentsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IEnumerable<Moment> Get () {
            var query = new AllMomentsQuery();

            var result = _queryDispatcher.Dispatch<AllMomentsQuery, AllMomentsQueryResult>(query);

            return result.Moments;
        }
    }
}