using Bogus;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain;
using Reaction_api.Domain.Test._Builders;
using Xunit;

namespace Reaction_api.Domain.Test
{
    public class MomentTest
    {
        public Faker faker { get; set; }
        public MomentTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Should_create_a_moment()
        {
            var expectedMoment = new
            {
                User = UserBuilder.Instance().Build(),
                ElapsedTime = faker.Date.ToString(),
                Picture = faker.Internet.Url(),
                Reactions = faker.Random.Number()
            };

            var moment = new Moment(expectedMoment.User,
                                    expectedMoment.ElapsedTime,
                                    expectedMoment.Picture,
                                    expectedMoment.Reactions);

            expectedMoment.ToExpectedObject().ShouldMatch(moment);
        }

        [Fact]
        public void Should_not_create_a_moment_without_user()
        {
            var exception = Assert.Throws<DomainException>(() => 
                MomentBuilder
                    .Instance()
                    .WithUser(null)
                    .Build()
            );

            Assert.Equal("User is required", exception.Message);
        }
    }
}