using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Test._Builders;
using Reaction_api.Domain.Test._Util;
using Xunit;

namespace Reaction_api.Domain.Test
{
    public class ReactionTeste
    {
        [Fact]
        public void Should_create_a_reaction()
        {
            var expectedReaction = new
            {
                User = UserBuilder.Instance().Build(),
                Type = "Like"
            };

            var reaction = new Reaction(expectedReaction.User, expectedReaction.Type);

            expectedReaction.ToExpectedObject().ShouldMatch(reaction);
        }

        [Fact]
        public void Should_not_create_a_reaction_without_user()
        {
            const string expectedMessage = "User is required";
            const string type = "Like";
            User user = null;

            void Action() => new Reaction(user, type);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_not_create_a_reaction_without_type(string invalidType)
        {
            const string expectedMessage = "Type is required";
            var user = UserBuilder.Instance().Build();

            void Action() => new Reaction(user, invalidType);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }
    }
}
