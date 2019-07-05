using Reaction_api.Domain._Exceptions;
using Xunit;

namespace Reaction_api.Domain.Test._Util
{
    public static class ExtensionMethods
    {
        public static void WithMessage(this DomainException exception, string message)
        {
           Assert.Equal(message, exception.Message);
        }
    }
}