using System.Collections;
using System.Collections.Generic;

namespace Reaction_api.Domain
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> Get();
    }
}