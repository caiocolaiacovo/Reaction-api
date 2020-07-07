using System;

namespace Reaction_api.Domain
{
    public class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}