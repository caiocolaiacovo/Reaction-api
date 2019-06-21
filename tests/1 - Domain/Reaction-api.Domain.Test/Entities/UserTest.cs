using Bogus;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Entities;
using Reaction_api.Domain.Test._Builders;
using Xunit;

namespace Reaction_api.Domain.Test.Entities
{
    public class UserTest
    {
        public Faker faker { get; set; }

        public UserTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Should_create_a_user()
        {
            var expectedUser = new
            {
                Name = faker.Person.FullName,
                Profile = faker.Person.UserName,
                Avatar = faker.Internet.Url(),
            };

            var user = UserBuilder.Instancia().ComNome(expectedUser.Name).
                  ComProfile(expectedUser.Profile).
                  ComAvatar(expectedUser.Avatar).
                  Construir();

            expectedUser.ToExpectedObject().ShouldMatch(user);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_not_create_a_user_without_name(string invalidName)
        {
            var exception = Assert.Throws<DomainException>(() =>
               UserBuilder.Instancia().ComNome(invalidName).Construir()
            );

            Assert.Equal("Name is required", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_not_create_a_user_without_profile(string invalidProfile)
        {
            var exception = Assert.Throws<DomainException>(() =>
                UserBuilder.Instancia().ComProfile(invalidProfile).Construir()
            );

            Assert.Equal("Profile is required", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_not_create_a_user_without_avatar(string invalidAvatar)
        {
            var exception = Assert.Throws<DomainException>(() =>
               UserBuilder.Instancia().ComAvatar(invalidAvatar).Construir()
            );

            Assert.Equal("Avatar is required", exception.Message);
        }
    }
}