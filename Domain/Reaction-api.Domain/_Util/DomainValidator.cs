using Reaction_api.Domain._Exceptions;

namespace Reaction_api.Domain._Util
{
    public class DomainValidator
    {
        public static DomainValidator New()
        {
            return new DomainValidator();
        }
        public DomainValidator When(bool condition, string message)
        {
            if (condition)
                throw new DomainException(message);

            return this;
        }
    }
}