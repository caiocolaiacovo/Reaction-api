using Bogus;

namespace Reaction_api.Domain.Test._Base
{
    public class UnitTestBase
    {
        public Faker faker { get; private set; }

        public UnitTestBase()
        {
            faker = new Faker();
        }
    }
}