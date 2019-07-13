using Bogus;

namespace Reaction_api.Domain.Test._Base
{
    public class BuilderBase
    {
        public Faker faker { get; protected set; }

        public BuilderBase()
        {
            faker = new Faker();
        }
    }
}